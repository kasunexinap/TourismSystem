using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Domain.Enums
{
    public enum TripStatus
    {
        Created = 0,
        Planned = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4
    }
}
