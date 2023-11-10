using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class TypepersonConfiguration : IEntityTypeConfiguration<Typeperson>
{
    public void Configure(EntityTypeBuilder<Typeperson> builder)
    {
        
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("typeperson");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");
    }
}
