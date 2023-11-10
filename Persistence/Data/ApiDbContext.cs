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
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("departament");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.IdGender, "FK_idGender");

            entity.HasIndex(e => e.IdTypeperson, "FK_idTypeperson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Birthdate).HasColumnName("birthdate");
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("city");
            entity.Property(e => e.IdGender).HasColumnName("idGender");
            entity.Property(e => e.IdTypeperson).HasColumnName("idTypeperson");
            entity.Property(e => e.Lastname1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("lastname1");
            entity.Property(e => e.Lastname2)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("lastname2");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("phone");

            entity.HasOne(d => d.Gender).WithMany(p => p.People)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idGender");

            entity.HasOne(d => d.Typeperson).WithMany(p => p.People)
                .HasForeignKey(d => d.IdTypeperson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idTypeperson");
        });

        modelBuilder.Entity<Schoolyear>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("schoolyear");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.YearEnd)
                .HasColumnType("year")
                .HasColumnName("yearEnd");
            entity.Property(e => e.YearStart)
                .HasColumnType("year")
                .HasColumnName("yearStart");
        });

        modelBuilder.Entity<Studenttuition>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("studenttuition");

            entity.HasIndex(e => e.IdPerson, "FK_idPersonStudent");

            entity.HasIndex(e => e.IdSchoolyear, "FK_idSchoolyear");

            entity.HasIndex(e => e.IdSubject, "FK_idSubject");

            entity.Property(e => e.IdPerson).HasColumnName("idPerson");
            entity.Property(e => e.IdSchoolyear).HasColumnName("idSchoolyear");
            entity.Property(e => e.IdSubject).HasColumnName("idSubject");

            entity.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idPersonStudent");

            entity.HasOne(d => d.Schoolyear).WithMany()
                .HasForeignKey(d => d.IdSchoolyear)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idSchoolyear");

            entity.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idSubject");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("subject");

            entity.HasIndex(e => e.IdGrade, "FK_idGrade");

            entity.HasIndex(e => e.IdTeacher, "FK_idTeacher");

            entity.HasIndex(e => e.IdTypesubject, "FK_idTypesubject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.Credit).HasColumnName("credit");
            entity.Property(e => e.FourMonthPeriod).HasColumnName("fourMonthPeriod");
            entity.Property(e => e.IdGrade).HasColumnName("idGrade");
            entity.Property(e => e.IdTeacher).HasColumnName("idTeacher");
            entity.Property(e => e.IdTypesubject).HasColumnName("idTypesubject");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasOne(d => d.Grade).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdGrade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idGrade");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idTeacher");

            entity.HasOne(d => d.Typesubject).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdTypesubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idTypesubject");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("teacher");

            entity.HasIndex(e => e.IdDepartament, "FK_idDepartament");

            entity.HasIndex(e => e.IdPerson, "FK_idPersonTeacher");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdDepartament).HasColumnName("idDepartament");
            entity.Property(e => e.IdPerson).HasColumnName("idPerson");

            entity.HasOne(d => d.Departament).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdDepartament)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idDepartament");

            entity.HasOne(d => d.Person).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idPersonTeacher");
        });

        modelBuilder.Entity<Typeperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typeperson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Typesubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typesubject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    /*protected override void OnModelCreating2(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }*/
}
