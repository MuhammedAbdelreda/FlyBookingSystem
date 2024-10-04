using FlyBookingSystem.IServices.Booking.Dtos;
using FlyBookingSystem.IServices.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Booking
{
    public interface IBookingService
    {
        Task Create(CreateUpdateBookingDto booking);
        Task Update(int id, CreateUpdateBookingDto booking);
        Task Delete(int id);
        Task<PagedResultDto<BookingDto>> GetListAsync(Specifications spec);
        Task<BookingDto> GetWithId(int id);
    }
}
