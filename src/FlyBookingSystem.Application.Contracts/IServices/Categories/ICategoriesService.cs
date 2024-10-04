using FlyBookingSystem.IServices.Categories.Dtos;
using FlyBookingSystem.IServices.Discount.Dtos;
using FlyBookingSystem.IServices.Flight.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices.Categories
{
    public interface ICategoriesService
    {
        Task Create(CreateUpdateCategoriesDto category);
        Task Update(int id, CreateUpdateCategoriesDto category);
        Task Delete(int id);
        //Task<PagedResultDto<CategoriesDto>> GetListAsync(Specifications spec);
        Task<List<CategoriesDto>> GetAll();
        Task<CategoriesDto> GetWithId(int id);
    }
}
