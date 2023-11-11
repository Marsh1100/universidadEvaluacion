using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Repository;

public class SchoolyearRepository : GenericRepository<Schoolyear>, ISchoolyear
{
    private readonly ApiDbContext _context;

    public SchoolyearRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }

    //Devuelve un listado que muestre cuántos alumnos se han matriculado de alguna asignatura en cada uno de los cursos escolares. El resultado deberá mostrar dos columnas, una columna con el año de inicio del curso escolar y otra con el número de alumnos matriculados.
    public async Task<IEnumerable<object>> GetStudentsTuition(int idSubject)
    {
        var result = await _context.Studenttuitions
                    .Include(e=>e.Person)
                    .Include(u=> u.Schoolyear)
                    .Where(a=> a.IdSubject == idSubject)
                    .GroupBy(a=>a.Schoolyear.YearStart)
                    .Select(p=> new{
                        start_year = p.Key,
                        Num_students = p.Select(o=>o.Person).Count()
                    })
                    .ToListAsync();
        return result;
    }
}
