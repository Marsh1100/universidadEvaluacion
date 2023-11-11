using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("person");

            builder.HasIndex(e => e.IdGender, "FK_idGender");

            builder.HasIndex(e => e.IdTypeperson, "FK_idTypeperson");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("address");
            builder.Property(e => e.Birthdate).HasColumnName("birthdate");
            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("city");
            builder.Property(e => e.IdGender).HasColumnName("idGender");
            builder.Property(e => e.IdTypeperson).HasColumnName("idTypeperson");
            builder.Property(e => e.Lastname1)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("lastname1");
            builder.Property(e => e.Lastname2)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("lastname2");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("name");
            builder.Property(e => e.Nit)
                .HasMaxLength(15)
                .HasColumnName("nit");
            builder.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");

            builder.HasOne(d => d.Gender).WithMany(p => p.People)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idGender");

            builder.HasOne(d => d.Typeperson).WithMany(p => p.People)
                .HasForeignKey(d => d.IdTypeperson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_idTypeperson");

    }
}
