using AutoMapper;
using NuretaNeko.API.Requests.Skill;
using NuretaNeko.AppModel.Services.Contracts;
using NuretaNeko.Domain.Entities;

namespace NuretaNeko.API.Mappings
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<AddSkillRequest, AddSkillDTO.Request>();
            CreateMap<AddSkillDTO.Request, Skill>();

            CreateMap<AddSkillOptionRequest, AddSkillOptionDTO.Request>();
            CreateMap<AddSkillOptionDTO.Request, SkillOption>();

            CreateMap<AddResumeRequest, AddResumeDTO.Request>().IncludeMembers();
            CreateMap<CandidateDTO, Candidate>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore());

        }
    }
}
