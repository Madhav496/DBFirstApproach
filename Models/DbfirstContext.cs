using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstApproach.Models;

public partial class DbfirstContext : DbContext
{
    public DbfirstContext()
    {
    }

    public DbfirstContext(DbContextOptions<DbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbfirstTable> DbfirstTables { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbfirstTable>(entity =>
        {
            entity.ToTable("DBFirst_Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
