﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.WebApp.Models;

namespace Test.WebApp.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        builder.HasKey(x => x.Id);
        builder.Property(x=>x.Name)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x=>x.Email).HasMaxLength(50).IsRequired();
        builder.Property(x=>x.Phone).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.RegistrationId).HasMaxLength(10).IsRequired();
    }
}
