using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using iText.Commons.Bouncycastle.Asn1;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRolRepository _roles;
    private IUserRepository _users;
    private IDepartament _departaments;
    private IGender _genders;
     private IGrade _grades;
    private IPerson _people;
    private ISchoolyear _schoolyears;
    private ISubject _subjects;
    private ITeacher _teachers;
    private ITypeperson _typepeople;
    private ITypesubject _typesubjects;

  
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }
    public IRolRepository Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }

    public IDepartament Departaments
    {
        get
        {
            if (_departaments == null)
            {
                _departaments = new DepartamentRepository(_context);
            }
            return _departaments;
        }
    }
     public IGender Genders
    {
        get
        {
            if (_genders == null)
            {
                _genders = new GenderRepository(_context);
            }
            return _genders;
        }
    }
    
     public IGrade Grades
    {
        get
        {
            if (_grades == null)
            {
                _grades = new GradeRepository(_context);
            }
            return _grades;
        }
    }
    
     public ISchoolyear Schoolyears
    {
        get
        {
            if (_schoolyears == null)
            {
                _schoolyears = new SchoolyearRepository(_context);
            }
            return _schoolyears;
        }
    }
    
     public ISubject Subjects
    {
        get
        {
            if (_subjects == null)
            {
                _subjects = new SubjectRepository(_context);
            }
            return _subjects;
        }
    }
    
    public ITeacher Teachers
    {
        get
        {
            if (_teachers == null)
            {
                _teachers = new TeacherRepository(_context);
            }
            return _teachers;
        }
    }
    
     public ITypeperson Typepeople
    {
        get
        {
            if (_typepeople == null)
            {
                _typepeople = new TypepersonRepository(_context);
            }
            return _typepeople;
        }
    }
    
     public ITypesubject Typesubjects
    {
        get
        {
            if (_typesubjects == null)
            {
                _typesubjects = new TypesubjectRepository(_context);
            }
            return _typesubjects;
        }
    }
    
    public IPerson People
    {
        get
        {
            if (_people == null)
            {
                _people = new PersonRepository(_context);
            }
            return _people;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}