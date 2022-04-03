using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public record CandidateCardDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public double Score { get; set; }
        public List<SkillInfoDTO> FormData { get; set; }
    }

    public record SkillInfoDTO
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
