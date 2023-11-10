using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class PersonRepository : GenericRepository<Person>, IPerson
{
    private readonly ApiDbContext _context;

    public PersonRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
