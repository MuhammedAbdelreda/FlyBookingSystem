using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class LoyaltyProgram:FullAuditedEntity<int>
    {
        public int CustomerId { get; set; }
        public int PointsEarned { get; set; }
        public string TierLevel { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
