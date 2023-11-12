using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class PersonRepository : GenericRepository<Person>, IPerson
{
    private readonly ApiDbContext _context;

    public PersonRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    public async Task<IEnumerable<object>> GetTeachersWithoutSubject()
    {
        var teachers = await _context.Teachers
            .Where(d => d.Subjects.All(q => q == null))
            .Select(p =>new
                {
                    p.Person.Lastname1,
                    p.Person.Lastname2,
                    p.Person.Name
                }
            ).OrderBy(p => p.Lastname1)
            .ThenBy(p => p.Lastname2)
            .ThenBy(p => p.Name)
            .ToListAsync();

        return teachers;
    }

    public override async Task<(int totalRegistros, IEnumerable<Person> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.People as IQueryable<Person>;
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
    public async Task<IEnumerable<Person>> GetWomansGrade()
    {
        var students = await _context.Studenttuitions
                        .Include(p=> p.Person).ThenInclude(e=> e.Gender)
                        .Include(o=> o.Subject).ThenInclude(a=>a.Grade)
                        .Where(p=> p.Person.IdGender == 2 && p.Subject.Grade.Name == "Grado en Ingeniería Informática (Plan 2015)")
                        .Select(s=> s.Person).Distinct()
                        .ToListAsync();
        return students;
    }

    public async Task<object> GetSbirthday1999()
    {

        var cant = await _context.People
                    .Where(p=> p.Birthdate.Year==1999 && p.IdTypeperson ==1).CountAsync();
        
        return new { Number_of_Students = cant};
    }

    public async Task<object> GetWomanStudents()
    {
        var cant = await _context.People
                    .Where(p=> p.IdGender == 2 && p.IdTypeperson==1).CountAsync();
        
        return new { Number_of_Women = cant};
    }

    public async Task<IEnumerable<Person>> GetYoungestStudent()
    {
        var year = await _context.People
                        .OrderByDescending(c=> c.Birthdate)
                        .Select(s=> s.Birthdate)
                        .FirstOrDefaultAsync();

        var student = await _context.People
                        .Include(a=> a.Gender)
                        .Where(a=>a.IdTypeperson == 1 && a.Birthdate == year)
                        .ToListAsync();

        return student;
    }

    public async Task<IEnumerable<object>> GetTeachersWithoutDepartment()
    {
        var peopleteachers = await _context.People.Where(e=>e.IdTypeperson==2).ToListAsync();
        var teachers = await _context.Teachers.ToListAsync();

        var result = (from personteacher in peopleteachers
                        join teacher in teachers on personteacher.Id equals teacher.IdPerson into h
                        from all in h.DefaultIfEmpty()
                        where  all?.IdDepartament == null
                        select new {
                            Teacher = personteacher.Name + " " + personteacher.Lastname1+" "+ personteacher.Lastname2
                        })
                        .Distinct();
        return result;
    }

    // Devuelve un listado con los profesores que tienen un departamento asociado y que no imparten ninguna asignatura.
    public async Task<IEnumerable<object>> GetTeachersWithOutSubject()
    {
        var teachers = await _context.Teachers.Include(a=> a.Person).ToListAsync();
        var subjects = await _context.Subjects.ToListAsync();

        var result = from teacher in teachers
                        join subject in subjects on teacher.Id equals subject.IdTeacher into h
                        from all in h.DefaultIfEmpty()
                        where all?.IdTeacher == null
                        select new 
                        {
                            Teacher = teacher.Person.Name + " " + teacher.Person.Lastname1+" "+ teacher.Person.Lastname2
                        };
        return result;
    }

    public async Task<IEnumerable<Person>> GetAllStudents()
    {
        var students = await _context.People
            .Where(e => e.IdTypeperson == 1)
            .OrderBy(p => p.Lastname1)
            .ThenBy(p => p.Lastname2)
            .ThenBy(p => p.Name)
            .ToListAsync();
        return students;
    }

    public async Task<IEnumerable<Person>> GetStudentsWithoutPhone()
    {
        var students = await _context.People
            .Where(e => e.IdTypeperson == 1 && e.Phone == null)
            .ToListAsync();

        return students;
    }

    public async Task<IEnumerable<Person>> GetStudents1999()
    {
        var students = await _context.People
                .Where(p => p.IdTypeperson == 1 && p.Birthdate.Year == 1999)
                .ToListAsync();

        return students;
    }

    public async Task<IEnumerable<Person>> GetTeacherWithoutPhoneK()
    {
        var teachers = await _context.People
            .Where(n => n.IdTypeperson == 2 && n.Phone == null && n.Nit.EndsWith("K"))
            .ToListAsync();

        return teachers;
    }
}
