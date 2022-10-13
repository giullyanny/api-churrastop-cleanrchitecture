using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIChurrasTop.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}