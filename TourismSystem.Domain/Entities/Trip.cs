using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Common;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Domain.Entities
{
    public class Trip:BaseEntity
    {
        public int Id { get; set; }
        public int? RegisteredVehicleId { get; set; }
        public decimal DistanceKm { get; set; }
        public decimal RatePerKm { get; set; }
        public decimal TotalCost { get; set; }
        public int VehicleId { get; set; }
        public TripStatus Status { get; set; } = TripStatus.Created;
    }
}
