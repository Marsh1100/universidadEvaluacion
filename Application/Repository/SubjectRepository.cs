using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubject
{
    private readonly ApiDbContext _context;

    public SubjectRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Subject> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Subjects as IQueryable<Subject>;
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

    //Devuelve el listado de las asignaturas que se imparten en el primer cuatrimestre, en el tercer curso, del grado que tiene el identificador `7`.
     public async Task<IEnumerable<Subject>> GetSubjectsCourse3()
    {
        var subjects = await _context.Subjects
                        .Include(o=>o.Grade)
                        .Where(a=>a.FourMonthPeriod == 1 && a.Course==3 && a.Grade.Id == 7)
                        .ToListAsync();
        return subjects;
    }

    public async Task<IEnumerable<Subject>> GetSubjectsGrade4()
    {
        var subjects = await _context.Subjects
                        .Include(o=>o.Grade)
                        .Where(a=>a.Grade.Name == "Grado en Ingeniería Informática (Plan 2015)")
                        .ToListAsync();
        return subjects;
    }

    //Devuelve un listado con el número de asignaturas que imparte cada profesor. El listado debe tener en cuenta aquellos profesores que no imparten ninguna asignatura. El resultado mostrará cinco columnas: id, nombre, primer apellido, segundo apellido y número de asignaturas. El resultado estará ordenado de mayor a menor por el número de asignaturas.
    public async Task<IEnumerable<object>> GetSubjectsByTeacher()
    {
        var subjects = await _context.Teachers
                        .Include(o=>o.Person)
                        .Select(o=> new
                        {
                            Id = o.Id,
                            o.Person.Name,
                            o.Person.Lastname1,
                            o.Person.Lastname2,
                            Num_of_subjects = o.Subjects.Count()
                        })
                        .OrderByDescending(a=>a.Num_of_subjects)
                        .ToListAsync();
        return subjects;
    }

    public async Task<IEnumerable<Subject>> GetWithoutTeacher()
    {
        var subjects = await _context.Subjects
                        .Include(a=> a.Grade)
                        .Include(p=> p.Typesubject)
                        .Where(s=> s.IdTeacher == null)
                        .ToListAsync();
        return subjects;
    }
}
