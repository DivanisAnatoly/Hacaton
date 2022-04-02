using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuretaNeko.API.Requests.Skill;
using NuretaNeko.AppModel.Services;
using NuretaNeko.AppModel.Services.Contracts;

namespace NuretaNeko.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppService _appService;


        public ResumeController(IMapper mapper, IAppService appService)
        {
            _mapper = mapper;
            _appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> AddResume([FromBody] AddResumeRequest request, CancellationToken cancellationToken)
        {
            var addResumeDTO = _mapper.Map<AddResumeDTO.Request>(request);
            var response = await _appService.AddResume(addResumeDTO, cancellationToken);
            return Ok(response);
        }


        [HttpGet]
        public async Task<IActionResult> GetResumes(CancellationToken cancellationToken)
        {
            //var getResumesDTO = _mapper.Map<GetResumesDTO.Request>(request);
            var response = await _appService.GetResumes(cancellationToken);
            return Ok(response);
        }

    }
}