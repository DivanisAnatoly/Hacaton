using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services.Contracts
{
    public record CandidateDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        //public IFormFile Photo { get; set; }
    }
}
