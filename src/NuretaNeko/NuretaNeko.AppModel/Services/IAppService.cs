using NuretaNeko.AppModel.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuretaNeko.AppModel.Services
{
    public interface IAppService
    {
        Task<AddSkillDTO.Response> AddSkill(AddSkillDTO.Request request, CancellationToken cancellationToken);
        Task<AddSkillOptionDTO.Response> AddSkillOption(AddSkillOptionDTO.Request request, CancellationToken cancellationToken);
        //Task<AddResumeDTO.Response> AddResume(AddResumeDTO.Request request, CancellationToken cancellationToken);
        Task<AddResumeDTO.Response> AddResume(AddResumeDTO.Request request, CancellationToken cancellationToken);
        Task<GetResumesDTO.Response> GetResumes(CancellationToken cancellationToken);
    }
}
