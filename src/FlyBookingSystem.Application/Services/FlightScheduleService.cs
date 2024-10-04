using FlyBookingSystem.IServices.Discount.Dtos;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.FlightSchedule;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using FlyBookingSystem.IServices.FlightSchedule.Dtos;
using Volo.Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;

namespace FlyBookingSystem.Services
{
    public class FlightScheduleService:BaseApplicationService,IFlightScheduleService
    {
        private readonly IRepository<FlightSchedule, int> repo;

        public FlightScheduleService(IRepository<FlightSchedule, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateFlightScheduleDto flightSchedule)
        {
            var result = ObjectMapper.Map<CreateUpdateFlightScheduleDto, FlightSchedule>(flightSchedule);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<FlightSchedule, FlightScheduleDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<FlightScheduleDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

/*            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p.AvailableSeats.Contains(spec.filter));
            }*/

            // Get total count for pagination
            var totalCount = await query.CountAsync();

            // Apply sorting (using dynamic LINQ)
            if (!string.IsNullOrEmpty(spec.Sorting))
            {
                query = query.OrderBy(spec.Sorting); // You might need dynamic LINQ for this
            }
            else
            {
                query = query.OrderBy(p => p.AvailableSeats); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<FlightScheduleDto>(
            totalCount,
                ObjectMapper.Map<List<FlightSchedule>, List<FlightScheduleDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<FlightScheduleDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<FlightSchedule, FlightScheduleDto>(result);

        }

        public async Task Update(int id, CreateUpdateFlightScheduleDto flightSchedule)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(flightSchedule, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
