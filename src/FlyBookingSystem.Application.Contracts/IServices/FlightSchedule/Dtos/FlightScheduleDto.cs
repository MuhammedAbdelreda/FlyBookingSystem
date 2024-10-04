using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.FlightSchedule.Dtos
{
    public class FlightScheduleDto:EntityDto<int>
    {
        public int FlightId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }
        public decimal Price { get; set; }
        public int AvailableSeats { get; set; }
    }
}
