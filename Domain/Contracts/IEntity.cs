using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Domain.Contracts
{
    public interface IEntity<Key>
    {
        Key Id { get; set; }
    }
}
