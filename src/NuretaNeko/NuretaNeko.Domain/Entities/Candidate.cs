using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public Guid ResumeId { get; set; }

        public virtual Resume Resume { get; set; }
    }
}
