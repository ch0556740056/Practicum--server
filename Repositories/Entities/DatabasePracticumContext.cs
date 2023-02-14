using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Entities;

public partial class DatabasePracticumContext : DbContext
{
    public DatabasePracticumContext()
    {
    }

    public DatabasePracticumContext(DbContextOptions<DatabasePracticumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-QM3UF42;Initial Catalog=databasePracticum;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Identity);

            entity.ToTable("Child");

            entity.Property(e => e.Identity).HasMaxLength(9);
            entity.Property(e => e.DateOfBirdth).HasColumnType("date");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentId).HasMaxLength(9);

            entity.HasOne(d => d.Parent).WithMany(p => p.Children)
                .HasForeignKey(d => d.ParentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Child_PersonalDetails");
        });

        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.Identity);

            entity.Property(e => e.Identity).HasMaxLength(9);
            entity.Property(e => e.DateOfBirdth).HasColumnType("date");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Hmo)
                .HasMaxLength(50)
                .HasColumnName("HMO");
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
