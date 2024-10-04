using FlyBookingSystem.IServices.Passenger.Dtos;
using FlyBookingSystem.IServices.Payment.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Payment
{
    public interface IPaymentService
    {
        Task Create(CreateUpdatePaymentDto payment);
        Task Update(int id, CreateUpdatePaymentDto payment);
        Task Delete(int id);
        Task<PagedResultDto<PaymentDto>> GetListAsync(Specifications spec);
        Task<PaymentDto> GetWithId(int id);
    }
}
