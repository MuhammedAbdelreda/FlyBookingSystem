using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities.Auditing;

namespace FlyBookingSystem.IServices.Categories.Dtos
{
    public class CategoriesDto:EntityDto<int>
    {
        public string Name { get; set; }
        public string Seat { get; set; }

        public string Bag { get; set; }

        public string Flexibility { get; set; }

        public double Price { get; set; }
    }
}
