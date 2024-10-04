using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.IServices.Categories.Dtos
{
    public class CreateUpdateCategoriesDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Seat { get; set; }
        [Required]
        [StringLength(50)]
        public string Bag { get; set; }
        [Required]
        [StringLength(50)]
        public string Flexibility { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
