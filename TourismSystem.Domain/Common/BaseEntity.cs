using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismSystem.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
