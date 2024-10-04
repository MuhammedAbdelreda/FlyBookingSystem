using FlyBookingSystem.IServices.LoyaltyProgram.Dtos;
using FlyBookingSystem.IServices.Passenger.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Passenger
{
    public interface IPassengerService
    {
        Task Create(CreateUpdatePassengerDto passenger);
        Task Update(int id, CreateUpdatePassengerDto passenger);
        Task Delete(int id);
        Task<PagedResultDto<PassengerDto>> GetListAsync(Specifications spec);
        Task<PassengerDto> GetWithId(int id);
    }
}
