using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Entities
{
    public class PagingParameters
    {
        const int maxPageSize = 50;

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; }

    }
}
