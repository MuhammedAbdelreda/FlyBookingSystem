using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Airport.Dtos
{
    public class AirportDto:EntityDto<int>
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Location { get; set; }
    }
}
