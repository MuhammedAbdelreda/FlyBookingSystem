using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.IServices.Flight.Dtos
{
    public class CreateUpdateFlightDto
    {
        [Required]
        public string Date { get; set; }
        [Required]
        public string DepartureTime { get; set; }
        [Required]
        public string ArrivalTime { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
