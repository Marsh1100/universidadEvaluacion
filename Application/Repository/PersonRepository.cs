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

    public async Task<object> GetSbirthday1999()
    {
        DateOnly year1999start = new(1999,1,1);
        DateOnly year1999end = new(1999,12,31);

        var cant = await _context.People
                    .Where(p=> p.Birthdate>= year1999start && p.Birthdate<= year1999end  && p.IdTypeperson ==1).CountAsync();
        
        return new { Number_of_Students = cant};
    }

    public async Task<object> GetWomanStudents()
    {
        var cant = await _context.People
                    .Where(p=> p.IdGender == 2 && p.IdTypeperson==1).CountAsync();
        
        return new { Number_of_Women = cant};
    }
}
