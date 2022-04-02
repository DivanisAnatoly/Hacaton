using NuretaNeko.AppModel.Services.Contracts;
using NuretaNeko.Domain.Entities.Enums;

namespace NuretaNeko.API.Requests.Skill
{
    public record AddResumeRequest
    {
        public CandidateDTO Candidate { get; set; }
        public ResumeDTO Resume { get; set; }
        
    }
}
