using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AnimalHabitat.Data.Models;

namespace AnimalHabitat.Data.Contexts
{
    public partial class AnimalHabitatContext : DbContext
    {
        public AnimalHabitatContext()
        {
        }

        public AnimalHabitatContext(DbContextOptions<AnimalHabitatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Continent> Continent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AnimalHabitat;Trusted_Connection=True;Connect Timeout=100");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.HasOne(d => d.Continent)
                    .WithMany(p => p.Animal)
                    .HasForeignKey(d => d.ContinentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_Continent");
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
