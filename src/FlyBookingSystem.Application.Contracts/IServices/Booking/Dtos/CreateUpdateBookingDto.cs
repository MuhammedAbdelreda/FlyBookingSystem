using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.IServices.Booking.Dtos
{
    public class CreateUpdateBookingDto
    {
        [Required]
        public string BookingReference { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public BookingStatus Status { get; set; }

        [Required]
        public int FlightScheduleId { get; set; }
    }
}
