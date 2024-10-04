using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.LoyaltyProgram;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using FlyBookingSystem.IServices.LoyaltyProgram.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FlyBookingSystem.Services
{
    public class LoyaltyProgramService:BaseApplicationService,ILoyaltyProgramService
    {
        private readonly IRepository<LoyaltyProgram, int> repo;

        public LoyaltyProgramService(IRepository<LoyaltyProgram, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateLoyaltyProgramDto loyaltyProgram)
        {
            var result = ObjectMapper.Map<CreateUpdateLoyaltyProgramDto, LoyaltyProgram>(loyaltyProgram);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<LoyaltyProgram, LoyaltyProgramDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<LoyaltyProgramDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p.TierLevel.Contains(spec.filter));
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
                query = query.OrderBy(p => p.TierLevel); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<LoyaltyProgramDto>(
            totalCount,
                ObjectMapper.Map<List<LoyaltyProgram>, List<LoyaltyProgramDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<LoyaltyProgramDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<LoyaltyProgram, LoyaltyProgramDto>(result);

        }

        public async Task Update(int id, CreateUpdateLoyaltyProgramDto loyaltyProgram)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(loyaltyProgram, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
