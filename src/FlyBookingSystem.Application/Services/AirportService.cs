using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Airport;
using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices.Customer.Dtos;
using FlyBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace FlyBookingSystem.Services
{
    public class AirportService:BaseApplicationService,IAirportService
    {
        private readonly IRepository<Airport, int> repo;

        public AirportService(IRepository<Airport, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateAirportDto airport)
        {
            var result = ObjectMapper.Map<CreateUpdateAirportDto, Airport>(airport);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Airport, AirportDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<AirportDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p.Name.Contains(spec.filter) || p.Code.Contains(spec.filter));
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
                query = query.OrderBy(p => p.Name); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<AirportDto>(
            totalCount,
                ObjectMapper.Map<List<Airport>, List<AirportDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<AirportDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Airport, AirportDto>(result);

        }

        public async Task Update(int id, CreateUpdateAirportDto airport)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(airport, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
