using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Application.Models.Paging;

namespace Catalog.API.Application.Models
{
    public class QueryData
    {
        public PagingParam? Paging { get; set; }
        public string Sort { get; set; } //? Id asc, Price desc
    }
}
