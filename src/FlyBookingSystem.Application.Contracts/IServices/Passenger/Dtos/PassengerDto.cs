using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Passenger.Dtos
{
    public class PassengerDto:EntityDto<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public int BookingId { get; set; }
    }
}
