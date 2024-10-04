using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.Models
{
    public class Categories:FullAuditedEntity<int>
    {
        public string Name {  get; set; }
        public string Seat {  get; set; }

        public string Bag {  get; set; }

        public string Flexibility {  get; set; }

        public double Price {  get; set; }
    }
}
