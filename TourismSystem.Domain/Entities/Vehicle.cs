using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismSystem.Domain.Common;

namespace TourismSystem.Domain.Entities
{
    public class Vehicle:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal RatePerKm { get; set; }
    }
}
