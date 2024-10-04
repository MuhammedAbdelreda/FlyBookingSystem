using FlyBookingSystem.IServices.Customer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Customer
{
    public interface ICustomerService
    {
        Task Create(CreateUpdateCustomerDto customer);
        Task Update(int id,CreateUpdateCustomerDto customer);
        Task Delete(int id);
        //Task<List<CustomerDto>> GetAll();
        Task<PagedResultDto<CustomerDto>> GetListAsync(Specifications spec);
        Task<CustomerDto> GetWithId(int id);
    }
}

/*TODO
 * Create
 * Update
 * Delete
 * Get
 * GetWithId
 * update Get->GetAsync With Specification
 */
