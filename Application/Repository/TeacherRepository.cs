using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class TeacherRepository : GenericRepository<Teacher>, ITeacher
{
    private readonly ApiDbContext _context;

    public TeacherRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<object>> GetAllTeachersDep()
    {
        var teachers = await _context.People
                        .Where(p => p.IdTypeperson ==2)
                        .Select(s =>new{
                                s.Lastname1,
                                s.Lastname2,
                                s.Name,
                                Departament = s.Teachers.Any() ? s.Teachers.First().Departament.Name: "Sin departamento"
                        })
                        .OrderBy(p => p.Departament)
                        .ThenBy(p => p.Lastname1)
                        .ThenBy(p => p.Lastname2)
                        .ThenBy(p => p.Name)
                        .ToListAsync();

                    return teachers;
    }


    public async Task<IEnumerable<object>> GetTeacherAndDepartament()
    {
        var teachers = await _context.Teachers
                        .Where(n => n.Person.IdTypeperson == 2)
                        .OrderBy(n => n.Person.Lastname1)
                        .ThenBy(n => n.Person.Lastname1)
                        .ThenBy(n => n.Person.Name)
                        .Select(s =>new {
                                    s.Person.Lastname1,
                                    s.Person.Lastname2,
                                    s.Person.Name,
                                    Departamento = s.Departament.Name
                                })
                        .ToListAsync();

        return teachers;
    }

    public async Task<IEnumerable<object>> GetTeacherWithoutDepartament()
    {
        var teachers = await _context.Teachers.ToListAsync();
        var people = await _context.People
                            .Where(a=>a.IdTypeperson == 2)
                            .ToListAsync();

        var result = (from person in people
                        join teacher in teachers on person.Id equals teacher.IdPerson into h
                        from all in h.DefaultIfEmpty()
                        where all?.IdDepartament == null
                        select new
                        {
                            teacher = person.Name+" "+person.Lastname1+" "+person.Lastname2
                        }).Distinct();
        
        return result;
    }
}
