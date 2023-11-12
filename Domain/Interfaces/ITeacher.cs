using Domain.Entities;

namespace Domain.Interfaces;

public interface ITeacher : IGenericRepository<Teacher> { 
    
    Task<IEnumerable<object>> GetTeacherAndDepartament();
    Task<IEnumerable<object>> GetAllTeachersDep();
    Task<IEnumerable<object>> GetTeacherWithoutDepartament();
}

