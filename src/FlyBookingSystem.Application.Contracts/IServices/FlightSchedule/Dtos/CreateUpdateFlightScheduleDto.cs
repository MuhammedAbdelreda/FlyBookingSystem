using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.IServices.FlightSchedule.Dtos
{
    public class CreateUpdateFlightScheduleDto
    {
        [Required]
        public int FlightId { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int DepartureAirportId { get; set; }

        [Required]
        public int ArrivalAirportId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int AvailableSeats { get; set; }
    }
}
