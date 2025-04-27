using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mini_Project_Core;

namespace Mini_Project_Repository.Data;

public partial class MiniProjectDbContext : DbContext
{
    public MiniProjectDbContext()
    {
    }

    public MiniProjectDbContext(DbContextOptions<MiniProjectDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=EnverSoft Mini Project;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.CompanyCode)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasDefaultValue("");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
