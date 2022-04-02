using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public record SkillOptionDTO
    {
        public string SkillKey { get; set; }
        public string OptionKey { get; set; } 
    }
}
