using Domain.Entities;

namespace Domain.Interfaces;

    public interface IPerson : IGenericRepository<Person> { 
    
    Task<object> GetWomanStudents();
    }

