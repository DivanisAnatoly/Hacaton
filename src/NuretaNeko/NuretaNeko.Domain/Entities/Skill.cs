using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public SkillPriority Priority { get; set; }
    }
}
