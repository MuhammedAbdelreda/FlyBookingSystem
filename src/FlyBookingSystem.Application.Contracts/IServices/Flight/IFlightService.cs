using FlyBookingSystem.IServices.Customer.Dtos;
using FlyBookingSystem.IServices.Flight.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Flight
{
    public interface IFlightService
    {
        Task Create(CreateUpdateFlightDto flight);
        Task Update(int id, CreateUpdateFlightDto flight);
        Task Delete(int id);
        //Task<PagedResultDto<FlightDto>> GetListAsync(Specifications spec);
        Task<List<FlightDto>> GetAll();
        Task<FlightDto> GetWithId(int id);
    }
}
