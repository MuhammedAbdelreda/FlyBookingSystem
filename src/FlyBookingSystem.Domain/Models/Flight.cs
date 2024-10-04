using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class Flight:FullAuditedEntity<int>
    {
        #region Old
        /*        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string AircraftModel { get; set; }
        public int Capacity { get; set; }
        public List<FlightSchedule> FlightSchedules { get; set; }*/
        #endregion
        public string Date { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price {  get; set; }
        public List<FlightSchedule> FlightSchedules { get; set; }
    }
}
