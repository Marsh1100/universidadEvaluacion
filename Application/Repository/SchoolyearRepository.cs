using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class SchoolyearRepository : GenericRepository<Schoolyear>, ISchoolyear
{
    private readonly ApiDbContext _context;

    public SchoolyearRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
