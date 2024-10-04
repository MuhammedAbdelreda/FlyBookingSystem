using FlyBookingSystem.IServices.Payment.Dtos;
using FlyBookingSystem.IServices.Staff.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Staff
{
    public interface IStaffService
    {
        Task Create(CreateUpdateStaffDto staff);
        Task Update(int id, CreateUpdateStaffDto staff);
        Task Delete(int id);
        Task<PagedResultDto<StaffDto>> GetListAsync(Specifications spec);
        Task<StaffDto> GetWithId(int id);
    }
}
