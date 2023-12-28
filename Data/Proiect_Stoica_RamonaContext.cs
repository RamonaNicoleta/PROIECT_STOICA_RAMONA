using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Stoica_Ramona.Models;

namespace Proiect_Stoica_Ramona.Data
{
    public class Proiect_Stoica_RamonaContext : DbContext
    {
        public Proiect_Stoica_RamonaContext (DbContextOptions<Proiect_Stoica_RamonaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Stoica_Ramona.Models.Car> Car { get; set; } = default!;

        public DbSet<Proiect_Stoica_Ramona.Models.Location>? Location { get; set; }

        public DbSet<Proiect_Stoica_Ramona.Models.EngineType>? EngineType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(b => b.Rent)
                .WithOne(b => b.Car)
                .HasForeignKey<Rent>(b => b.CarID);

        }

        public DbSet<Proiect_Stoica_Ramona.Models.Client>? Client { get; set; }

        public DbSet<Proiect_Stoica_Ramona.Models.Rent>? Rent { get; set; }
    }
}
