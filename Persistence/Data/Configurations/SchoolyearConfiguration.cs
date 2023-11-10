using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class SchoolyearConfiguration : IEntityTypeConfiguration<Schoolyear>
{
    public void Configure(EntityTypeBuilder<Schoolyear> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("schoolyear");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.YearEnd)
                .HasColumnType("year")
                .HasColumnName("yearEnd");
            builder.Property(e => e.YearStart)
                .HasColumnType("year")
                .HasColumnName("yearStart");
    }
}
