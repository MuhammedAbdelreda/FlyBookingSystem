using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class Airport:FullAuditedEntity<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
        public List<FlightSchedule> DepartureFlightSchedules { get; set; }
        public List<FlightSchedule> ArrivalFlightSchedules { get; set; }
    }
}
