using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SwaggerWeb.Api.Models;

public partial class SwaggerDbContext : DbContext
{
    //Scaffold-DbContext "Data Source=***;Initial Catalog=***;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

    public SwaggerDbContext()
    {
    }

    public SwaggerDbContext(DbContextOptions<SwaggerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json")
              .Build();

        var connectionString = configuration.GetConnectionString("ConStr");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
