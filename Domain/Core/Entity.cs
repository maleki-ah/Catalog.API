using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Domain.Contracts;

namespace Catalog.API.Domain.Core
{
    public abstract class Entity<Key> : IEntity<Key>
    {
        public required Key Id { get; set; }
    }
}
