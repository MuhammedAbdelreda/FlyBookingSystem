using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Airport
{
    public interface IAirportService
    {
        Task Create(CreateUpdateAirportDto airport);
        Task Update(int id, CreateUpdateAirportDto airport);
        Task Delete(int id);
        Task<PagedResultDto<AirportDto>> GetListAsync(Specifications spec);
        Task<AirportDto> GetWithId(int id);
    }
}
