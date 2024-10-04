using FlyBookingSystem.IServices.Customer.Dtos;
using FlyBookingSystem.IServices.Discount.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Discount
{
    public interface IDiscountService
    {
        Task Create(CreateUpdateDiscountDto discount);
        Task Update(int id, CreateUpdateDiscountDto discount);
        Task Delete(int id);
        Task<PagedResultDto<DiscountDto>> GetListAsync(Specifications spec);
        Task<DiscountDto> GetWithId(int id);
    }
}
