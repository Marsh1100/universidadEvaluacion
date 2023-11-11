using Domain.Entities;

namespace Domain.Interfaces;

public interface ISchoolyear : IGenericRepository<Schoolyear> { 
   Task<IEnumerable<object>> GetStudentsTuition(int IdSubject); 
}

