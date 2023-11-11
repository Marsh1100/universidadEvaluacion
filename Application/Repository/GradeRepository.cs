using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class GradeRepository : GenericRepository<Grade>, IGrade
{
    private readonly ApiDbContext _context;

    public GradeRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Grade> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Grades as IQueryable<Grade>;
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

    public async Task<IEnumerable<object>> GetSubjectsbyGrades()
    {
        var grades = await _context.Grades.Include(e=>e.Subjects)
                    .Select(a=> new{
                        Grade = a.Name,
                        Num_of_subjects= a.Subjects.Count()
                    })
                    .OrderByDescending(a=>a.Num_of_subjects)
                    .ToListAsync();
        
        return grades;

    }
   
    public async Task<IEnumerable<object>> GetMore40subject()
    {
        var grades = await _context.Grades.Include(e=>e.Subjects).ThenInclude(u=>u.Typesubject)
                    .Where(a=> a.Subjects.Count()> 40)
                    .Select(a=> new{
                        Grade = a.Name,
                        Num_of_subjects= a.Subjects.Count()
                    })
                    .ToListAsync();
        return grades;
    }
    public async Task<IEnumerable<object>> GetSubjectsTypeByGrades()
    {
        var grades = await _context.Grades.Include(e=>e.Subjects).ThenInclude(u=>u.Typesubject)
                    .Select(a=> new{
                        Grade = a.Name,
                        Type_subject = a.Subjects.Select(a=>a.Typesubject.Name).FirstOrDefault() ?? "No hay asignaturas asociadas al grado",
                        Num_of_credits= a.Subjects.Sum(a=>a.Credit)
                    })
                    .OrderByDescending(p=>p.Num_of_credits)
                    .ToListAsync();
        return grades;
    }
}
