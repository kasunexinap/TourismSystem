using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Domain.Enums
{
    public enum TripStatus
    {
        Created = 1,
        Assigned = 2,
        InProgress = 3,
        Completed = 4,
        Cancelled = 5
    }
}
