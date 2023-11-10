using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("teacher");

        builder.HasIndex(e => e.IdDepartament, "FK_idDepartament");

        builder.HasIndex(e => e.IdPerson, "FK_idPersonTeacher");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.IdDepartament).HasColumnName("idDepartament");
        builder.Property(e => e.IdPerson).HasColumnName("idPerson");

        builder.HasOne(d => d.Departament).WithMany(p => p.Teachers)
            .HasForeignKey(d => d.IdDepartament)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_idDepartament");

        builder.HasOne(d => d.Person).WithMany(p => p.Teachers)
            .HasForeignKey(d => d.IdPerson)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_idPersonTeacher");
    }
}
