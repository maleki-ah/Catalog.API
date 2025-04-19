using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Application.Models.Paging
{
    public class PagedList<TEntity> : List<TEntity>
    {
        public int TotalRecords { get; init; }

        public PagedList(IEnumerable<TEntity> items, int totalRecords)
        {
            AddRange(items);
            TotalRecords = totalRecords;
        }
    }
}
