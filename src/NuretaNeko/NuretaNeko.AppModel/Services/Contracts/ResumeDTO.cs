using Microsoft.AspNetCore.Http;
using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public record ResumeDTO
    {
        public Position Position { get; set; }
        //public List<SkillOptionDTO> SkillsInfo { get; set; }
        public Dictionary<string,string> SkillsInfo { get; set; }
    }
}
