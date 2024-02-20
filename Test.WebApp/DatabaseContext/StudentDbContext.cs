﻿using Microsoft.EntityFrameworkCore;

namespace Test.WebApp.DatabaseContext;

public class StudentDbContext(DbContextOptions<StudentDbContext> dbContext) : DbContext(dbContext)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentDbContext).Assembly);
    }
}
