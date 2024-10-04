using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.LoyaltyProgram.Dtos
{
    public class LoyaltyProgramDto:EntityDto<int>
    {
        public int CustomerId { get; set; }
        public int PointsEarned { get; set; }
        public string TierLevel { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
