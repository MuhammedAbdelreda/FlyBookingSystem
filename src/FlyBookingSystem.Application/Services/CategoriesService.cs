using FlyBookingSystem.IServices;
using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices.Categories;
using FlyBookingSystem.IServices.Categories.Dtos;
using FlyBookingSystem.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class CategoriesService : BaseApplicationService, ICategoriesService
    {
        private readonly IRepository<Categories, int> repo;

        public CategoriesService(IRepository<Categories,int> repo)
        {
            this.repo = repo;
        }
        public async Task Create(CreateUpdateCategoriesDto category)
        {
            var result = ObjectMapper.Map<CreateUpdateCategoriesDto, Categories>(category);
            var result2 = await repo.InsertAsync(result);
            ObjectMapper.Map<Categories, CategoriesDto>(result2);
        }

        public async Task Delete(int id)
        {
            var resultToDelete = await repo.GetAsync(id);
            await repo.DeleteAsync(resultToDelete);
        }


        /*        public async Task<PagedResultDto<CategoriesDto>> GetListAsync(Specifications spec)
                {
                    // Query with filtering
                    var query = await repo.WithDetailsAsync();

                    if (!spec.filter.IsNullOrWhiteSpace())
                    {
                        query = query.Where(p => p.Seat.Contains(spec.filter) || p.Bag.Contains(spec.filter));
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
                        query = query.OrderBy(p => p.Seat); // Default sorting by FirstName
                    }

                    // Apply pagination
                    var result = await query
                        .Skip(spec.SkipCount)
                        .Take(spec.MaxResultCount)
                        .ToListAsync();

                    // Map the result to DTOs
                    var resultToReturn = new PagedResultDto<CategoriesDto>(
                    totalCount,
                        ObjectMapper.Map<List<Categories>, List<CategoriesDto>>(result)
                    );

                    return resultToReturn;
                }*/

        public async Task<List<CategoriesDto>> GetAll()
        {
            var result = await repo.ToListAsync();
            var resultToReturn = ObjectMapper.Map<List<Categories>,List<CategoriesDto>>(result);
            return resultToReturn;
        }
        public async Task<CategoriesDto> GetWithId(int id)
        {
            var result = await repo.GetAsync(id);
            return ObjectMapper.Map<Categories,CategoriesDto>(result);
        }

        public async Task Update(int id, CreateUpdateCategoriesDto category)
        {
            var result = await repo.GetAsync(id);
            var resultToReturn = ObjectMapper.Map(category, result);
            await repo.UpdateAsync(resultToReturn);
        }
    }
}
