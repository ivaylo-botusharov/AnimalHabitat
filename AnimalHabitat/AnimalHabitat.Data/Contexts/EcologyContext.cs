using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AnimalHabitat.Data.Models;

namespace AnimalHabitat.Data.Contexts
{
    public partial class EcologyContext : DbContext
    {
        public EcologyContext()
        {
        }

        public EcologyContext(DbContextOptions<EcologyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Biome> Biome { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Ecoregion> Ecoregion { get; set; }
        public virtual DbSet<EcoregionCountry> EcoregionCountry { get; set; }
        public virtual DbSet<Realm> Realm { get; set; }
        public virtual DbSet<RealmBiome> RealmBiome { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<SpeciesDistribution> SpeciesDistribution { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Ecology;Trusted_Connection=True;Connect Timeout=100");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Biome>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Ecoregion>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.HasOne(d => d.RealmBiome)
                    .WithMany(p => p.Ecoregion)
                    .HasForeignKey(d => new { d.RealmId, d.BiomeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RealmBiome");
            });

            modelBuilder.Entity<EcoregionCountry>(entity =>
            {
                entity.HasKey(e => new { e.EcoregionId, e.CountryId })
                    .HasName("PK_Ecoregion_Country");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.EcoregionCountry)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Country");

                entity.HasOne(d => d.Ecoregion)
                    .WithMany(p => p.EcoregionCountry)
                    .HasForeignKey(d => d.EcoregionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ecoregion");
            });

            modelBuilder.Entity<Realm>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<RealmBiome>(entity =>
            {
                entity.HasKey(e => new { e.RealmId, e.BiomeId })
                    .HasName("PK_Realm_Biome");

                entity.HasOne(d => d.Biome)
                    .WithMany(p => p.RealmBiome)
                    .HasForeignKey(d => d.BiomeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Biome");

                entity.HasOne(d => d.Realm)
                    .WithMany(p => p.RealmBiome)
                    .HasForeignKey(d => d.RealmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Realm");
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.CommonName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ScientificName).HasMaxLength(100);
            });

            modelBuilder.Entity<SpeciesDistribution>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_SpeciesDistribution_Id")
                    .IsClustered(false);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.SpeciesDistribution)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpeciesDistribution_Species");

                entity.HasOne(d => d.EcoregionCountry)
                    .WithMany(p => p.SpeciesDistribution)
                    .HasForeignKey(d => new { d.EcoregionId, d.CountryId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SpeciesDistribution_EcoregionCountry");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
