using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Common;
using TourismSystem.Domain.Enums;

namespace TourismSystem.Domain.Entities
{
    public class RegisteredVehicle : BaseEntity
    {
        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; }

        public string LicenseNumber { get; set; }

        public string OwnerName { get; set; }

        public string OwnerContactNo { get; set; }

        public int ManufactureYear { get; set; }

        public string? Color { get; set; }

        public bool IsAvailable { get; set; } = true;
        public RegisteredVehicleStatus Status { get; set; }
    = RegisteredVehicleStatus.Available;

        public VehicleCondition Condition { get; set; }
    = VehicleCondition.Good;
    }
}
