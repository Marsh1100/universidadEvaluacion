using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("subject");

            builder.HasIndex(e => e.IdGrade, "FK_idGrade");

            builder.HasIndex(e => e.IdTeacher, "FK_idTeacher");

            builder.HasIndex(e => e.IdTypesubject, "FK_idTypesubject");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Course).HasColumnName("course");
            builder.Property(e => e.Credit).HasColumnName("credit");
            builder.Property(e => e.FourMonthPeriod).HasColumnName("fourMonthPeriod");
            builder.Property(e => e.IdGrade).HasColumnName("idGrade");
            builder.Property(e => e.IdTeacher).HasColumnName("idTeacher");
            builder.Property(e => e.IdTypesubject).HasColumnName("idTypesubject");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

            builder.HasOne(d => d.Grade).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdGrade)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idGrade");

            builder.HasOne(d => d.Teacher).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idTeacher");

            builder.HasOne(d => d.Typesubject).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.IdTypesubject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idTypesubject");
    }
}
