using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_Tecnica.Models;

public partial class Prueba_Tecnica_GuatemalaDigitalContext : DbContext
{
    public Prueba_Tecnica_GuatemalaDigitalContext()
    {
    }

    public Prueba_Tecnica_GuatemalaDigitalContext(DbContextOptions<Prueba_Tecnica_GuatemalaDigitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__Categori__3CEE2F4C961B6431");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__785B009E76F0E68F");

            entity.ToTable("Producto");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.ObjetoCategorium).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CodigoCategoria)
                .HasConstraintName("FK__Producto__Codigo__398D8EEE");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.CodigoVenta).HasName("PK__Venta__F2421464C83C63D3");

            entity.HasOne(d => d.ObjetoProducto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CodigoProducto)
                .HasConstraintName("FK__Venta__CodigoPro__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
