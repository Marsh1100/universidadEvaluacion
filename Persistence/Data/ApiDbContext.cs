using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;

namespace Persistence.Data;

public partial class ApiDbContext : DbContext
{

    public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<UserRol> UserRoles { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Schoolyear> Schoolyears { get; set; }

    public virtual DbSet<Studenttuition> Studenttuitions { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Typeperson> Typepeople { get; set; }

    public virtual DbSet<Typesubject> Typesubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
