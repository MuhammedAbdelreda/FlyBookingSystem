using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Flight.Dtos
{
    public class FlightDto:EntityDto<int>
    {
        public string Date { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }
    }
}
