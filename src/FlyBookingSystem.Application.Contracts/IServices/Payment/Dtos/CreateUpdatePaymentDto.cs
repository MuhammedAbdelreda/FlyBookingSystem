using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FlyBookingSystem.Models.Payment;

namespace FlyBookingSystem.IServices.Payment.Dtos
{
    public class CreateUpdatePaymentDto
    {
        [Required]
        public int BookingId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        public PaymentStatus Status { get; set; }
    }
}
