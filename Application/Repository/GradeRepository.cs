using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class GradeRepository : GenericRepository<Grade>, IGrade
{
    private readonly ApiDbContext _context;

    public GradeRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
