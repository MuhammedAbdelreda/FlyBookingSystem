using FlyBookingSystem.IServices.Booking.Dtos;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Discount;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using FlyBookingSystem.IServices.Discount.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FlyBookingSystem.Services
{
    public class DiscountService:BaseApplicationService,IDiscountService
    {
        private readonly IRepository<Discount, int> repo;

        public DiscountService(IRepository<Discount, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateDiscountDto discount)
        {
            var result = ObjectMapper.Map<CreateUpdateDiscountDto, Discount>(discount);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Discount, DiscountDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<DiscountDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p.Code.Contains(spec.filter));
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
                query = query.OrderBy(p => p.Code); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<DiscountDto>(
            totalCount,
                ObjectMapper.Map<List<Discount>, List<DiscountDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<DiscountDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Discount, DiscountDto>(result);

        }

        public async Task Update(int id, CreateUpdateDiscountDto discount)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(discount, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
