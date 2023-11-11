using Domain.Entities;

namespace Domain.Interfaces;

public interface IGrade : IGenericRepository<Grade> { 
   Task<IEnumerable<object>> GetSubjectsbyGrades(); 
   Task<IEnumerable<object>> GetSubjectsTypeByGrades();
   Task<IEnumerable<object>> GetMore40subject();
}

