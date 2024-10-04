using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Flight;
using FlyBookingSystem.IServices.Flight.Dtos;
using FlyBookingSystem.IServices.FlightSchedule.Dtos;
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

namespace FlyBookingSystem.Services
{
    public class FlightService:BaseApplicationService,IFlightService
    {
        private readonly IRepository<Flight, int> repo;

        public FlightService(IRepository<Flight, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateFlightDto flight)
        {
            var result = ObjectMapper.Map<CreateUpdateFlightDto, Flight>(flight);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Flight, FlightDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        /*        public async Task<PagedResultDto<FlightDto>> GetListAsync(Specifications spec)
                {
                    // Query with filtering
                    var query = await repo.WithDetailsAsync();

                    if (!spec.filter.IsNullOrWhiteSpace())
                    {
                        query = query.Where(p => p.Date.Contains(spec.filter));
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
                        query = query.OrderBy(p => p.Date); // Default sorting by FirstName
                    }

                    // Apply pagination
                    var result = await query
                        .Skip(spec.SkipCount)
                        .Take(spec.MaxResultCount)
                        .ToListAsync();

                    // Map the result to DTOs
                    var resultToReturn = new PagedResultDto<FlightDto>(
                    totalCount,
                        ObjectMapper.Map<List<Flight>, List<FlightDto>>(result)
                    );

                    return resultToReturn;
                }*/
        #endregion

        public async Task<List<FlightDto>> GetAll()
        {
            var result = await repo.ToListAsync();
            var resultToReturn = ObjectMapper.Map<List<Flight>, List<FlightDto>>(result);
            return resultToReturn;
        }
        public async Task<FlightDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Flight, FlightDto>(result);

        }

        public async Task Update(int id, CreateUpdateFlightDto flight)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(flight, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
