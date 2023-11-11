using Domain.Entities;

namespace Domain.Interfaces;

public interface ISubject : IGenericRepository<Subject> { 
   Task<IEnumerable<Subject>> GetWithoutTeacher(); 
}

