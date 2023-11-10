using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TypesubjectRepository : GenericRepository<Typesubject>, ITypesubject
{
    private readonly ApiDbContext _context;

    public TypesubjectRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
