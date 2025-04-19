using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Application.Models.Paging
{
    public class PagingParam
    {
        public const int DefaultPageSize = 10;
        public const int MaxPageSize = 50;

        private int _pageSize = DefaultPageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
        public int PageIndex { get; set; } = 1;
    }
}
