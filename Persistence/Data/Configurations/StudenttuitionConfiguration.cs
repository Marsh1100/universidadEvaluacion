using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class StudenttuitionConfiguration : IEntityTypeConfiguration<Studenttuition>
{
    public void Configure(EntityTypeBuilder<Studenttuition> builder)
    {
         builder
                .HasNoKey()
                .ToTable("studenttuition");

            builder.HasIndex(e => e.IdPerson, "FK_idPersonStudent");

            builder.HasIndex(e => e.IdSchoolyear, "FK_idSchoolyear");

            builder.HasIndex(e => e.IdSubject, "FK_idSubject");

            builder.Property(e => e.IdPerson).HasColumnName("idPerson");
            builder.Property(e => e.IdSchoolyear).HasColumnName("idSchoolyear");
            builder.Property(e => e.IdSubject).HasColumnName("idSubject");

            builder.HasOne(d => d.Person).WithMany()
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idPersonStudent");

            builder.HasOne(d => d.Schoolyear).WithMany()
                .HasForeignKey(d => d.IdSchoolyear)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idSchoolyear");

            builder.HasOne(d => d.Subject).WithMany()
                .HasForeignKey(d => d.IdSubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idSubject");

    }
}
