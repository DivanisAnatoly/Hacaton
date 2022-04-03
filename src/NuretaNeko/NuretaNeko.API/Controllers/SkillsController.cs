using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuretaNeko.API.Requests.Skill;
using NuretaNeko.AppModel.Services;
using NuretaNeko.AppModel.Services.Contracts;

namespace NuretaNeko.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SkillsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAppService _appService;


        public SkillsController(IMapper mapper, IAppService appService)
        {
            _mapper = mapper;
            _appService = appService;
        }

     

        [HttpPost]
        public async Task<IActionResult> AddSkill([FromForm] AddSkillRequest request, CancellationToken cancellationToken)
        {
            var addSkillDTO = _mapper.Map<AddSkillDTO.Request>(request);
            var response = await _appService.AddSkill(addSkillDTO, cancellationToken);
            return Ok(response);
        }

        [HttpPost("options")]
        public async Task<IActionResult> AddSkillOption([FromForm] AddSkillOptionRequest request, CancellationToken cancellationToken)
        {
            var addSkillOptionDTO = _mapper.Map<AddSkillOptionDTO.Request>(request);
            var response = await _appService.AddSkillOption(addSkillOptionDTO, cancellationToken);
            return Ok(response);
        }

    }
}