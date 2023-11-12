using Domain.Entities;

namespace Domain.Interfaces;

public interface ISubject : IGenericRepository<Subject> {

   Task<IEnumerable<Subject>> GetSubjectsCourse3();
   Task<IEnumerable<Subject>> GetSubjectsGrade4();
   Task<IEnumerable<Subject>> GetWithoutTeacher(); 
   Task<IEnumerable<object>> GetSubjectsByTeacher();
}



