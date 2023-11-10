using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TypepersonRepository : GenericRepository<Typeperson>, ITypeperson
{
    private readonly ApiDbContext _context;

    public TypepersonRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
