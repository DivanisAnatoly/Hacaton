using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public static class AddSkillDTO
    {
        public record Request
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public SkillPriority Priority { get; set; }
        }

        public record Response
        {
            public Guid Guid { get; init; }
            public bool IsSuccess { get; init; }
            public string ErrorMsg { get; init; }
        }

    }
}
