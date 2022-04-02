using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Entities
{
    public class Resume : BaseEntity
    {
        public Position Position { get; set; }
        public string FormData { get; set; }
        public double Score { get; set; }
    }
}
