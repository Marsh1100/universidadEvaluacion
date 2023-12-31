using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Domain.Entities;
namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDto>()
            .ReverseMap();
        CreateMap<Rol, RolDto>()
            .ForMember(dest=>dest.Rol, origen=> origen.MapFrom(origen=> origen.Name.ToString()))
            .ReverseMap();
        CreateMap<User,UserAllDto>()
            .ForMember(dest=>dest.Roles, origen=> origen.MapFrom(origen=> origen.Roles))
            .ReverseMap();
        CreateMap<Person, PersonDto>()
            .ReverseMap();
        CreateMap<Departament, DepartamentDto>()
            .ReverseMap();
        CreateMap<Grade, GradeDto>()
            .ReverseMap();
        CreateMap<Schoolyear, SchoolyearDto>()
            .ReverseMap();
        CreateMap<Subject, SubjectDto>()
            .ReverseMap();
        CreateMap<Teacher, TeacherDto>()
            .ReverseMap();
        CreateMap<Subject, SubjectWithoutTeacherDto>()
            .ForMember(dest=>dest.Typesubject, origen=> origen.MapFrom(origen=> origen.Typesubject.Name))
            .ForMember(dest=>dest.Grade, origen=> origen.MapFrom(origen=> origen.Grade.Name))
            .ReverseMap();
        
        CreateMap<Subject, DepartamentSubjectDto>()
            .ForMember(dest=>dest.Departament, origen=> origen.MapFrom(origen=> origen.Teacher.Departament.Name))
            .ForMember(dest=>dest.Subject, origen=> origen.MapFrom(origen=> origen.Name))
            .ReverseMap();
        CreateMap<Person, PersonAllDto>()
            .ForMember(dest=>dest.Gender, origen=> origen.MapFrom(origen=> origen.Gender.Name))
            .ReverseMap();
        CreateMap<Person, PersonOnlyNameDto>()
            .ReverseMap();
        CreateMap<Subject, SubjectOnlyDto>()
            .ReverseMap();

    }
}
