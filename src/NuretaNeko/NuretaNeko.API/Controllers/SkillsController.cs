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

        //[HttpGet]
        //public async Task<IActionResult> GetDish([FromQuery]GetDishRequest request, CancellationToken cancellationToken)
        //{
        //    var getDishDTO = _mapper.Map<GetDishDTO.Request>(request);
        //    var response = await _dishService.GetDish(getDishDTO, cancellationToken);
        //    return Ok(response);
        //}

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

        //[HttpDelete]
        //public async Task<IActionResult> DeleteDish(DeleteDishRequest request, CancellationToken cancellationToken)
        //{
        //    var deleteDishDTO = _mapper.Map<DeleteDishDTO.Request>(request);
        //    var response = await _dishService.DeleteDish(deleteDishDTO, cancellationToken);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateDish(UpdateDishRequest request, CancellationToken cancellationToken)
        //{
        //    return Ok();
        //}


        //[HttpPost("AddCategory")]
        //public async Task<IActionResult> AddCategory([FromForm] AddDishCategoryRequest request, CancellationToken cancellationToken)
        //{
        //    var addDishCategoryDTO = _mapper.Map<AddDishCategoryDTO.Request>(request);
        //    var response = await _dishService.AddDishCategory(addDishCategoryDTO, cancellationToken);
        //    return Ok(response);
        //}

        //[HttpGet("GetCategories")]
        //public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
        //{
        //    var response = await _dishService.GetDishCategories(cancellationToken);
        //    return Ok(response);
        //}


        //[HttpGet("GetCategories/{id}")]
        //public async Task<IActionResult> GetCategories(Guid id, CancellationToken cancellationToken)
        //{
        //    var response = await _dishService.GetDishCategory(id, cancellationToken);
        //    return Ok(response);
        //}

        //[HttpDelete("DeleteCategory/{id}")]
        //public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
        //{
        //    var response = await _dishService.DeleteDishCategory(id, cancellationToken);
        //    return Ok(response);
        //}

    }
}