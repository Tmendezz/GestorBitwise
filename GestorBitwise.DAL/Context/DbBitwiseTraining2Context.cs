using System;
using System.Collections.Generic;
using GestorBitwise.ENTITY;
using Microsoft.EntityFrameworkCore;

namespace GestorBitwise.DAL;

public partial class DbBitwiseTraining2Context : DbContext
{
    public DbBitwiseTraining2Context()
    {
    }

    public DbBitwiseTraining2Context(DbContextOptions<DbBitwiseTraining2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Configuracion> Configuracione { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<NumeroCorrelativo> NumeroCorrelativo { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07203136D2");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleV__3214EC07BE4B1F3F");

            entity.Property(e => e.CategoriaProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MarcaProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__DetalleVe__Produ__4222D4EF");

            entity.HasOne(d => d.Venta).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Ventaid)
                .HasConstraintName("FK__DetalleVe__Venta__412EB0B6");
        });

        modelBuilder.Entity<NumeroCorrelativo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NumeroCo__3214EC0791CAF028");

            entity.ToTable("NumeroCorrelativo");

            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07707A091C");

            entity.ToTable("Producto");

            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Producto__Catego__3A81B327");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3214EC079421C8E1");

            entity.Property(e => e.DocumentoCliente)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
