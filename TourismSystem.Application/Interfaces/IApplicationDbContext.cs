using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace TourismSystem.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Vehicle> Vehicles { get; }
        DbSet<RegisteredVehicle> RegisteredVehicles { get; }
        DbSet<Trip> Trips { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
