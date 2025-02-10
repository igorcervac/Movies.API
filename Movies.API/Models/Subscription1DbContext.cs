using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Movies.API.Models;

public partial class Subscription1DbContext : DbContext
{
    private string _connectionString;

    public Subscription1DbContext()
    {
        _connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MoviesDB");
    }

    public Subscription1DbContext(DbContextOptions<Subscription1DbContext> options)
        : base(options)
    {
        _connectionString = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_MoviesDB");
    }

    public virtual DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Movies");

            entity.ToTable("Movies", "Movies");

            entity.Property(e => e.ImdbId)
                .HasMaxLength(50)
                .HasColumnName("ImdbID");
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Year).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
