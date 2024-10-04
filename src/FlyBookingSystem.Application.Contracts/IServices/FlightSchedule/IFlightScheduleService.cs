using FlyBookingSystem.IServices.Customer.Dtos;
using FlyBookingSystem.IServices.FlightSchedule.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.FlightSchedule
{
    public interface IFlightScheduleService
    {
        Task Create(CreateUpdateFlightScheduleDto flightSchedule);
        Task Update(int id, CreateUpdateFlightScheduleDto flightSchedule);
        Task Delete(int id);
        Task<PagedResultDto<FlightScheduleDto>> GetListAsync(Specifications spec);
        Task<FlightScheduleDto> GetWithId(int id);
    }
}
