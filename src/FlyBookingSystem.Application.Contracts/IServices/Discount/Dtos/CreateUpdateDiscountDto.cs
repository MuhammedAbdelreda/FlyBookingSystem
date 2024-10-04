using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.IServices.Discount.Dtos
{
    public class CreateUpdateDiscountDto
    {
        [Required]
        [StringLength(20)]
        public string Code { get; set; }

        [Range(0, 100)]
        public int Percentage { get; set; }

        [Required]
        public DateTime ValidFrom { get; set; }

        [Required]
        public DateTime ValidTo { get; set; }
    }
}
