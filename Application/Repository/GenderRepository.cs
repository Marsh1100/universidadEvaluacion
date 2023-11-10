using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class GenderRepository : GenericRepository<Gender>, IGender
{
    private readonly ApiDbContext _context;

    public GenderRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
