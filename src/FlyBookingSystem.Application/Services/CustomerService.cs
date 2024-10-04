using AutoMapper.Internal.Mappers;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Customer;
using FlyBookingSystem.IServices.Customer.Dtos;
using FlyBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Specifications;
using static Volo.Abp.UI.Navigation.DefaultMenuNames.Application;

namespace FlyBookingSystem.Services
{
    public class CustomerService : BaseApplicationService, ICustomerService
    {
        private readonly IRepository<Customer, int> repo;

        public CustomerService(IRepository<Customer,int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateCustomerDto customer)
        {
            var result = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(customer);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Customer, CustomerDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithoutSpecification
        /*        public async Task<List<CustomerDto>> GetAll()
                {
                    var result = await repo.GetListAsync();
                    return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(result);
                } */
        #endregion

        #region GetAllWithSpecification
        public async Task<PagedResultDto<CustomerDto>> GetListAsync(Specifications spec)
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
            var resultToReturn = new PagedResultDto<CustomerDto>(
            totalCount,
                ObjectMapper.Map<List<Customer>, List<CustomerDto>>(result)
            );

            return resultToReturn;
        }
        #endregion
        #region EnhancedSpcifications
        /*        public async Task<PagedResultDto<CustomerDto>> GetListAsync(EnhancedSpecifications spec)
                {
                    try
                    {
                        // Get the queryable set of customers
                        var query = repo.WithDetails();

                        // Apply filters
                        query = spec.ApplyFilters(query);

                        // Get total count for pagination
                        var totalCount = await query.CountAsync();

                        // Apply sorting
                        query = spec.ApplySorting(query);

                        // Apply pagination
                        var result = await query
                            .Skip((spec.PageNumber - 1) * spec.PageSize)
                            .Take(spec.PageSize)
                            .ToListAsync();

                        // Map the result to DTOs using ObjectMapper
                        var resultToReturn = new PagedResultDto<CustomerDto>(
                            totalCount,
                            ObjectMapper.Map<List<Customer>, List<CustomerDto>>(result)
                        );

                        return resultToReturn;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        // _logger.LogError(ex, "Error occurred in GetListAsync");

                        // Optionally, rethrow or return a custom error response
                        throw new UserFriendlyException("An error occurred while fetching the data.");
                    }
                }*/

        #endregion

        public async Task<CustomerDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Customer,CustomerDto>(result);
            
        }

        public async Task Update(int id,CreateUpdateCustomerDto customer)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(customer, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}





/*
         public async Task<PagedResultDto<AdminDto>> GetListAsync(Specifications spec)
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
            var resultToReturn = new PagedResultDto<AdminDto>(
                totalCount,
                ObjectMapper.Map<List<Admin>, List<AdminDto>>(result)
            );

            return resultToReturn;
        }
*/
