using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{

    public static class GetResumeDTO
    {
        public record Response
        {
            public CandidateCardDTO Card { get; init; }
            public bool IsSuccess { get; init; }
            public string ErrorMsg { get; init; }
        }

    }
}
