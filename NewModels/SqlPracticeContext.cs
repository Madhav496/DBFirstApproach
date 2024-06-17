using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataBaseFirstApproach.CTEModels;

namespace DataBaseFirstApproach.NewModels;

public partial class SqlPracticeContext : DbContext
{
    public SqlPracticeContext()
    {
    }

    public SqlPracticeContext(DbContextOptions<SqlPracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cricketer> Cricketers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cricketer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Wokers__3214EC07D40CD09C");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DepartName).HasMaxLength(20);
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<DataBaseFirstApproach.CTEModels.CteTable> CteTable { get; set; } = default!;
}
