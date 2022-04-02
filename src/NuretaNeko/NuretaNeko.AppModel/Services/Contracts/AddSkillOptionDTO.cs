using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public static class AddSkillOptionDTO
    {
        public record Request
        {
            public string OptionKey { get; init; }
            public string Value { get; init; }
            public int Score { get; init; }
            public Guid SkillId { get; init; }
        }

        public record Response
        {
            public Guid Guid { get; init; }
            public bool IsSuccess { get; init; }
            public string ErrorMsg { get; init; }
        }

    }
}
