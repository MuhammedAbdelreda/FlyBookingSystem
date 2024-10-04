using FlyBookingSystem.IServices.FlightSchedule.Dtos;
using FlyBookingSystem.IServices.LoyaltyProgram.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.LoyaltyProgram
{
    public interface ILoyaltyProgramService
    {
        Task Create(CreateUpdateLoyaltyProgramDto loyaltyProgram);
        Task Update(int id, CreateUpdateLoyaltyProgramDto loyaltyProgram);
        Task Delete(int id);
        Task<PagedResultDto<LoyaltyProgramDto>> GetListAsync(Specifications spec);
        Task<LoyaltyProgramDto> GetWithId(int id);
    }
}
