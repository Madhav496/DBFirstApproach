using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirstApproach.CTEModels;

public partial class SqlPracticeContext : DbContext
{
    public SqlPracticeContext()
    {
    }

    public SqlPracticeContext(DbContextOptions<SqlPracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CteTable> CteTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PICSLIN031; Initial Catalog=sqlPractice; Integrated Security=True; Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CteTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CTE_Tabl__3214EC27698190EB");

            entity.ToTable("CTE_Table");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartName).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
