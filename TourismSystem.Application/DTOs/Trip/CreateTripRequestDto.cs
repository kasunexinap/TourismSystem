using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Application.DTOs.Trip
{
    public class CreateTripRequestDto
    {
        public int VehicleId { get; set; }

        public decimal DistanceKm { get; set; }
    }
}
