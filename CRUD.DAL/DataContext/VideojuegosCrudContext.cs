using System;
using System.Collections.Generic;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.DAL.DataContext;

public partial class VideojuegosCrudContext : DbContext
{
    public VideojuegosCrudContext()
    {
    }

    public VideojuegosCrudContext(DbContextOptions<VideojuegosCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Consola> Consolas { get; set; }

    public virtual DbSet<Juego> Juegos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consola>(entity =>
        {
            entity.HasKey(e => e.IdConsola);

            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreConsola)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Juego>(entity =>
        {
            entity.HasKey(e => e.IdVideojuego);

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
