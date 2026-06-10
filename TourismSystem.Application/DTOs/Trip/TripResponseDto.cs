using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Application.DTOs.Trip
{
    public class TripResponseDto
    {
        public int TripId { get; set; }

        public string VehicleName { get; set; }

        public string? LicenseNumber { get; set; }

        public decimal DistanceKm { get; set; }

        public decimal RatePerKm { get; set; }

        public decimal TotalCost { get; set; }

        public TripStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
