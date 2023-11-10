using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class DepartamentRepository : GenericRepository<Departament>, IDepartament
{
    private readonly ApiDbContext _context;

    public DepartamentRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
