using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class Booking:FullAuditedEntity<int>
    {
        public string BookingReference { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalAmount { get; set; }
        public BookingStatus Status { get; set; }
        public int CustomerId { get; set; }
        public int FlightScheduleId { get; set; }
        public List<Passenger> Passengers { get; set; }
    }
}
