using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.Domain.Entities
{
    public class SkillOption : BaseEntity
    {
        public string OptionKey { get; set; }
        public string Value { get; set; }
        public int Score { get; set; }
        public Guid SkillId { get; set; }

        public virtual Skill Skill{ get; set; }
    }
}
