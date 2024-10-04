using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Volo.Abp.Application.Dtos;


namespace FlyBookingSystem.IServices
{
    public class EnhancedSpecifications : PagedAndSortedResultRequestDto
    {
        // Filter criteria: Dictionary where key is the field name and value is the filter value
        public Dictionary<string, string>? Filters { get; set; } = new Dictionary<string, string>();

        // Sorting criteria: Dictionary where key is the field name and value is the sort direction ("asc" or "desc")
        public Dictionary<string, string>? Sorting { get; set; } = new Dictionary<string, string>();

        // Pagination properties
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Method to apply filters
        public IQueryable<T> ApplyFilters<T>(IQueryable<T> query) where T : class
        {
            if (Filters != null && Filters.Any())
            {
                foreach (var filter in Filters)
                {
                    var property = typeof(T).GetProperty(filter.Key);
                    if (property != null)
                    {
                        var filterValue = filter.Value;
                        query = query.Where(x => property.GetValue(x).ToString().Contains(filterValue) == true);
                        //query = query.Where(x => property.GetValue(x)?.ToString().Contains(filterValue) == true);
                    }
                }
            }
            return query;
        }

        // Method to apply sorting
        public IQueryable<T> ApplySorting<T>(IQueryable<T> query) where T : class
        {
            if (Sorting != null && Sorting.Any())
            {
                var firstSort = Sorting.First();
                var sortExpression = $"{firstSort.Key} {firstSort.Value}";
                query = query.OrderBy(sortExpression);

                // Apply additional sorts if needed
                foreach (var sort in Sorting.Skip(1))
                {
                    sortExpression = $"{sort.Key} {sort.Value}";
                    query = query.OrderBy(sortExpression);
                }
            }
            else
            {
                query = query.OrderBy(x => x.GetType().GetProperty("Id").GetValue(x)); // Default sorting
            }

            return query;
        }
    }
}