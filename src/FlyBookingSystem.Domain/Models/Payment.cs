using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class Payment:FullAuditedEntity<int>
    {
        public int BookingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod PaymentMethods { get; set; }
        public PaymentStatus Status { get; set; }
    }
}
