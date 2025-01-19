using System;
using System.Collections.Generic;
using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.Contexts;

public partial class MyWebCvContext : DbContext
{
    public MyWebCvContext()
    {
    }

    public MyWebCvContext(DbContextOptions<MyWebCvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comments> Comments { get; set; }

    public virtual DbSet<Datas> Datas { get; set; }

    public virtual DbSet<Projects> Projects { get; set; }

    public virtual DbSet<Skills> Skills { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MyWebCv;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comments>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC070D6C558E");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comments__UserId__440B1D61");
        });

        modelBuilder.Entity<Datas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Datas__3214EC07BB063F98");

            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Education).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Mobile).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Projects>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Projects__3214EC074616096A");
        });

        modelBuilder.Entity<Skills>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07CF0B6884");

            entity.Property(e => e.Skill).HasMaxLength(50);
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC079E99C27D");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.RegistrationTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Role).HasDefaultValueSql("((0))");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
