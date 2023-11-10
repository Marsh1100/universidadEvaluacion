using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class SubjectRepository : GenericRepository<Subject>, ISubject
{
    private readonly ApiDbContext _context;

    public SubjectRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
