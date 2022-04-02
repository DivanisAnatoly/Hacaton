using NuretaNeko.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public static class AddResumeDTO
    {
        public record Request
        {
            public CandidateDTO Candidate { get; init; }
            public ResumeDTO Resume { get; init; }
        }

        public record Response
        {
            public Guid Guid { get; init; }
            public bool IsSuccess { get; init; }
            public string ErrorMsg { get; init; }
        }

    }
}
