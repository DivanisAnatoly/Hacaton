using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{

    public static class GetResumesDTO
    {
        public record Response
        {
            public List<ShortCandidateCardDTO> Cards { get; init; }
            public bool IsSuccess { get; init; }
            public string ErrorMsg { get; init; }
        }

    }
}
