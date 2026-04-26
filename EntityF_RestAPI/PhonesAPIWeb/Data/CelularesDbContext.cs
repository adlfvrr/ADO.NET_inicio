using System;
using System.Collections.Generic;
using PhonesAPIWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace PhonesAPIWeb.Data;

public partial class CelularesDbContext : DbContext
{
    public CelularesDbContext()
    {
    }

    public CelularesDbContext(DbContextOptions<CelularesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Iphone> Iphones { get; set; }

    public virtual DbSet<Phone> Phones { get; set; }

    public virtual DbSet<Samsung> Samsungs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=your_db;Username=your_user;Password=your_pass;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Iphone>(entity =>
        {
            entity.HasKey(e => e.IdPhone).HasName("iphone_pkey");

            entity.ToTable("iphone");

            entity.Property(e => e.IdPhone)
                .ValueGeneratedNever()
                .HasColumnName("id_phone");
            entity.Property(e => e.CondBateria)
                .HasMaxLength(50)
                .HasColumnName("cond_bateria");
            entity.Property(e => e.IdType)
                .HasDefaultValue(1)
                .HasColumnName("id_type");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");

            entity.HasOne(d => d.IdPhoneNavigation).WithOne(p => p.Iphone)
                .HasForeignKey<Iphone>(d => d.IdPhone)
                .HasConstraintName("fk_id_iphone");
        });

        modelBuilder.Entity<Phone>(entity =>
        {
            entity.HasKey(e => e.IdPhone).HasName("phones_pkey");

            entity.ToTable("phones");

            entity.Property(e => e.IdPhone).HasColumnName("id_phone");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");
        });

        modelBuilder.Entity<Samsung>(entity =>
        {
            entity.HasKey(e => e.IdPhone).HasName("samsung_pkey");

            entity.ToTable("samsung");

            entity.Property(e => e.IdPhone)
                .ValueGeneratedNever()
                .HasColumnName("id_phone");
            entity.Property(e => e.IdType)
                .HasDefaultValue(2)
                .HasColumnName("id_type");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.Price)
                .HasPrecision(18, 2)
                .HasColumnName("price");
            entity.Property(e => e.Serie)
                .HasMaxLength(50)
                .HasColumnName("serie");

            entity.HasOne(d => d.IdPhoneNavigation).WithOne(p => p.Samsung)
                .HasForeignKey<Samsung>(d => d.IdPhone)
                .HasConstraintName("fk_id_samsung");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
