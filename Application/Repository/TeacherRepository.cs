using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class TeacherRepository : GenericRepository<Teacher>, ITeacher
{
    private readonly ApiDbContext _context;

    public TeacherRepository(ApiDbContext context) : base(context)
    {
       _context = context;
    }
}
