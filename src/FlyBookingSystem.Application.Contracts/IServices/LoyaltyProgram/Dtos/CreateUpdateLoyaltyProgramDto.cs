using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.IServices.LoyaltyProgram.Dtos
{
    public class CreateUpdateLoyaltyProgramDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Range(0, int.MaxValue)]
        public int PointsEarned { get; set; }

        [StringLength(50)]
        public string TierLevel { get; set; }

        [Required]
        public DateTime MembershipDate { get; set; }
    }
}
