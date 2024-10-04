#region old specifications
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace FlyBookingSystem.IServices
{
    public class Specifications : PagedAndSortedResultRequestDto
    {
        public string? filter { get; set; }
    }
}
#endregion
