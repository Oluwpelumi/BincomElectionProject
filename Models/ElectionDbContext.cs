using BincomElectionProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BincomElectionProject.Models
{
    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext(DbContextOptions<ElectionDbContext> options) : base(options) { }

        public DbSet<PollingUnit> PollingUnits { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Lga> Lgas { get; set; }
        public DbSet<AnnouncedPuResult> AnnouncedPuResults { get; set; }
        public DbSet<AnnouncedLgaResult> AnnouncedLgaResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lga>(entity =>
            {
                entity.Property(e => e.DateEntered)
                      .HasColumnType("datetime")
                      .IsRequired(false); // Allows NULL values

                entity.Property(l => l.LgaId)
                     .HasColumnName("lga_id"); // Maps LgaId to 'lga_id'

            });

            modelBuilder.Entity<Lga>()
                .ToTable("lga"); // Ensure the table name matches exactly

            modelBuilder.Entity<Ward>()
                .ToTable("Ward"); // Ensure the table name matches exactly

            modelBuilder.Entity<PollingUnit>()
                .ToTable("polling_unit"); // Ensure the table name matches exactly

            modelBuilder.Entity<AnnouncedPuResult>()
                .ToTable("announced_pu_results"); // Ensure the table name matches exactly

            modelBuilder.Entity<AnnouncedLgaResult>()
               .ToTable("announced_lga_results"); // Ensure the table name matches exactly




            modelBuilder.Entity<AnnouncedLgaResult>()
                .HasKey(a => a.ResultId); // Specify the primary key

            modelBuilder.Entity<AnnouncedPuResult>()
                .HasKey(a => a.ResultId); // Specify the primary key
        }

    }
}
