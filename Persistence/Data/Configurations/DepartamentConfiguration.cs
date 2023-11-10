using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class DepartamentConfiguration : IEntityTypeConfiguration<Departament>
{
    public void Configure(EntityTypeBuilder<Departament> builder)
    {
        
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("departament");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");
    }
}
