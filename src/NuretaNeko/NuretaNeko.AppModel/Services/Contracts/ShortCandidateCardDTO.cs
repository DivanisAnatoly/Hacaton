using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public record ShortCandidateCardDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        public double Score { get; set; }

    }
}
