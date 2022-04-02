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


            //CreateMap<decimal, decimal>().ConvertUsing(x => Convert.ToDecimal(x));

            //CreateMap<DishDTO, Dish>()
            //    .ForMember(dest => dest.Photo, opt => opt.Ignore());
            //CreateMap<Dish, DishDTO>()
            //    .ForMember(dest => dest.Photo, opt => opt.Ignore());
            //CreateMap<DishCategory, DishCategoryDTO>();



            //CreateMap<AddDishRequest, AddDishDTO.Request>();
            //CreateMap<AddDishCategoryRequest, AddDishCategoryDTO.Request>();
            //CreateMap<DeleteDishRequest, DeleteDishDTO.Request>();
            //CreateMap<GetDishRequest, GetDishDTO.Request>();


            //CreateMap<AddDishDTO.Request, Dish>()
            //    .ForMember(dest => dest.Photo, opt => opt.Ignore());

            //CreateMap<AddDishCategoryDTO.Request, DishCategory>();

            //CreateMap<UserEditRequest, EditUser.Request>();
        }
    }
}
