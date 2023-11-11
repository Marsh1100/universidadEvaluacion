using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class DepartamentRepository : GenericRepository<Departament>, IDepartament
{
    private readonly ApiDbContext _context;

    public DepartamentRepository(ApiDbContext context) : base(context)
    {
       _context = context;
       
    }

    public override async Task<(int totalRegistros, IEnumerable<Departament> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Departaments as IQueryable<Departament>;
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p=>p.Name.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query 
                            .Skip((pageIndex-1)*pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<IEnumerable<List<Subject>>> GetSubjectDepartament()
    {
        var subjects = await _context.Subjects
                        .Include(o=> o.Teacher).ThenInclude(p=>p.Departament)
                        .ToListAsync();
        var tuitions = await _context.Studenttuitions
                        .ToListAsync();

        var result = (from subject in subjects
                     join tuition in tuitions on subject.Id  equals tuition.IdSubject into g
                     from all in g.DefaultIfEmpty()
                     where all?.IdSubject == null
                     select subjects).Distinct();
        
        return result;                             

    }
     public async Task<IEnumerable<object>> GetSubjectDepartament2()
    {
        var teachers = await _context.Teachers.Include(o=>o.Person).Include(p=>p.Departament).ToListAsync();
        var subjects = await _context.Subjects
                        .ToListAsync();
        var tuitions = await _context.Studenttuitions
                        .ToListAsync();

        var result = (from subject in subjects
                     join tuition in tuitions on subject.Id  equals tuition.IdSubject into g
                     from all in g.DefaultIfEmpty()
                     join teacher in teachers on subject.IdTeacher equals teacher.Id into h
                     from all2 in h.DefaultIfEmpty()
                     select  new {
                        Departament = all2?.Departament.Name ?? "Sin profesor asignado",
                        Subject = subject.Name,
                        IdSubject = subject.Id,
                        idSubject = all?.IdSubject ?? 0
                     }).Where(a=> a.idSubject == 0)
                     .Select(u=> new{
                        u.Departament,
                        u.Subject,
                        u.IdSubject
                     })
                     .Distinct();
        
        return result;                             

    }

    public async Task<IEnumerable<object>> GetTeachersByDepartment()
    {
        var result = await _context.Departaments
                        .Where(d=> d.Teachers.Count()>0)
                        .Select(a=> new{
                            Departament = a.Name,
                            Num_of_teachers = a.Teachers.Count()
                        })
                        .OrderByDescending(e=> e.Num_of_teachers)
                        .ToListAsync();

        return result;
    }
    public async Task<IEnumerable<object>> GetTeachersByDepartmentAll()
    {
        var result = await _context.Departaments
                        .Select(a=> new{
                            Departament = a.Name,
                            Num_of_teachers = a.Teachers.Count()
                        })
                        .ToListAsync();

        return result;
    }
}
