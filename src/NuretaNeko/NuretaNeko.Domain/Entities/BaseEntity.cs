using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Guid { get; set; }
    }
}
