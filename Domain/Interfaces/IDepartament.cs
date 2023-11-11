using Domain.Entities;

namespace Domain.Interfaces;

public interface IDepartament : IGenericRepository<Departament> { 
    Task<IEnumerable<List<Subject>>> GetSubjectDepartament();
    Task<IEnumerable<object>> GetSubjectDepartament2();
    Task<IEnumerable<object>> GetTeachersByDepartment();
    Task<IEnumerable<object>> GetTeachersByDepartmentAll();


    
}

