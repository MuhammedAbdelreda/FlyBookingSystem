using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class Discount:FullAuditedEntity<int>
    {
        public string Code { get; set; }
        public int Percentage { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
