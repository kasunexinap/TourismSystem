using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Entities;

namespace TourismSystem.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<RegisteredVehicle> RegisteredVehicles { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
