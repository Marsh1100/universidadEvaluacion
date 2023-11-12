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
                    }
            )
            .ToListAsync();

        return teachers;
    }
}
