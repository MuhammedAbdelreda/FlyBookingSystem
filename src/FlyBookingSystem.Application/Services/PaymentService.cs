using FlyBookingSystem.IServices.Passenger.Dtos;
using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Payment;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using FlyBookingSystem.IServices.Payment.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FlyBookingSystem.Services
{
    public class PaymentService:BaseApplicationService,IPaymentService
    {
        private readonly IRepository<Payment, int> repo;

        public PaymentService(IRepository<Payment, int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdatePaymentDto payment)
        {
            var result = ObjectMapper.Map<CreateUpdatePaymentDto, Payment>(payment);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Payment, PaymentDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }

        #region GetAllWithSpecification
        public async Task<PagedResultDto<PaymentDto>> GetListAsync(Specifications spec)
        {
            // Query with filtering
            var query = await repo.WithDetailsAsync();

/*            if (!spec.filter.IsNullOrWhiteSpace())
            {
                query = query.Where(p => p..Contains(spec.filter) || p.LastName.Contains(spec.filter));
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
                query = query.OrderBy(p => p.Amount); // Default sorting by FirstName
            }

            // Apply pagination
            var result = await query
                .Skip(spec.SkipCount)
                .Take(spec.MaxResultCount)
                .ToListAsync();

            // Map the result to DTOs
            var resultToReturn = new PagedResultDto<PaymentDto>(
            totalCount,
                ObjectMapper.Map<List<Payment>, List<PaymentDto>>(result)
            );

            return resultToReturn;
        }
        #endregion

        public async Task<PaymentDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Payment, PaymentDto>(result);

        }

        public async Task Update(int id, CreateUpdatePaymentDto payment)
        {
            var reusltToUpdate = await repo.GetAsync(id);
            ObjectMapper.Map(payment, reusltToUpdate);
            await repo.UpdateAsync(reusltToUpdate);
        }
    }
}
