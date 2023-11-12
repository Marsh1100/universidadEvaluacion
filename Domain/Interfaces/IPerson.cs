using Domain.Entities;

namespace Domain.Interfaces;

    public interface IPerson : IGenericRepository<Person> { 
    
    Task<object> GetWomanStudents();
    Task<object> GetSbirthday1999();

    Task<IEnumerable<Person>> GetYoungestStudent();
    Task<IEnumerable<object>> GetTeachersWithoutDepartment();

    Task<IEnumerable<object>> GetTeachersWithOutSubject();
    }

