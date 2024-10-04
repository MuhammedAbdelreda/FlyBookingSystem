using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Staff;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using FlyBookingSystem.IServices.Staff.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FlyBookingSystem.Services
{
    public class StaffService:BaseApplicationService,IStaffService
    {
        private readonly IRepository<Staff, int> repo;

        public StaffService(IRepository<Staff, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateStaffDto staff)
        {
            var result = ObjectMapper.Map<CreateUpdateStaffDto, Staff>(staff);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Staff, StaffDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<StaffDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p.FirstName.Contains(spec.filter) || p.LastName.Contains(spec.filter));
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
                query = query.OrderBy(p => p.FirstName); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<StaffDto>(
            totalCount,
                ObjectMapper.Map<List<Staff>, List<StaffDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<StaffDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Staff, StaffDto>(result);

        }

        public async Task Update(int id, CreateUpdateStaffDto staff)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(staff, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
