using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }
    IDepartament Departaments { get; }
    IGender Genders { get; }
    IGrade Grades { get; }
    IPerson People { get; }
    ISchoolyear Schoolyears { get; }
    ISubject Subjects { get; }
    ITeacher Teachers { get; }
    ITypeperson Typepeople { get; }
    ITypesubject Typesubjects { get; }

    Task<int> SaveAsync();
}
