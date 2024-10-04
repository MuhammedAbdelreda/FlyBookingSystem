using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Booking;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using FlyBookingSystem.IServices.Booking.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FlyBookingSystem.Services
{
    public class BookingService:BaseApplicationService,IBookingService
    {
        private readonly IRepository<Booking, int> repo;

        public BookingService(IRepository<Booking, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateBookingDto booking)
        {
            var result = ObjectMapper.Map<CreateUpdateBookingDto, Booking>(booking);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Booking, BookingDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<BookingDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p.BookingReference.Contains(spec.filter));
            }

            // Get total count for pagination
            var totalCount = await query.CountAsync();

            // Apply sorting (using dynamic LINQ)
            if (!string.IsNullOrEmpty(spec.Sorting))
            {
                query = query.OrderBy(spec.Sorting); // You might need dynamic LINQ for this
            }
            else
            {
                query = query.OrderBy(p => p.BookingReference); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<BookingDto>(
            totalCount,
                ObjectMapper.Map<List<Booking>, List<BookingDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<BookingDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Booking, BookingDto>(result);

        }

        public async Task Update(int id, CreateUpdateBookingDto booking)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(booking, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
