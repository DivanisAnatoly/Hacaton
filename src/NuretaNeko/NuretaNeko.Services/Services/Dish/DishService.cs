namespace NuretaNeko.Services.Services.Dish
{
    public class DishService //: IDishService
    {
        //private readonly IStorageService _storageService;
        //private readonly IDishRepository _dishRepository;
        //private readonly IDishCategoryRepository _dishCategoryRepository;
        //private readonly IMapper _mapper;

        //public DishService(IDishRepository dishRepository, IMapper mapper, IStorageService storageService,
        //    IDishCategoryRepository dishCategoryRepository)
        //{
        //    _dishRepository = dishRepository;
        //    _mapper = mapper;
        //    _storageService = storageService;
        //    _dishCategoryRepository = dishCategoryRepository;
        //}


        //public async Task<AddDishDTO.Response> AddDish(AddDishDTO.Request request, CancellationToken cancellationToken)
        //{
        //    var dish = _mapper.Map<Domain.Entities.Service.Dish>(request);
        //    //dish.Photo = "link";
        //    string fileName = await _storageService.SaveDishPhoto(request.Photo, cancellationToken);
        //    if (fileName == null)
        //    {
        //        return new AddDishDTO.Response
        //        {
        //            IsSuccess = false,
        //            ErrorMsg = "Storage error"
        //        };
        //    }
        //    dish.Photo = fileName;
        //    dish.DishStatus = DishStatus.Active;
        //    await _dishRepository.Add(dish, cancellationToken);
        //    return new AddDishDTO.Response
        //    {
        //        Guid = dish.Guid,
        //        IsSuccess = true
        //    };
        //}

        //public async Task<AddDishCategoryDTO.Response> AddDishCategory(AddDishCategoryDTO.Request request, CancellationToken cancellationToken)
        //{
        //    var dishCategory = _mapper.Map<Domain.Entities.Service.DishCategory>(request);
        //    await _dishCategoryRepository.Add(dishCategory, cancellationToken);
        //    return new AddDishCategoryDTO.Response
        //    {
        //        Guid = dishCategory.Guid,
        //        IsSuccess = true
        //    };
        //}

        //public async Task<DeleteDishDTO.Response> DeleteDish(DeleteDishDTO.Request request, CancellationToken cancellationToken)
        //{
        //    var dish = await _dishRepository.FindById(request.Guid, cancellationToken);
        //    if (dish != null)
        //    {
        //        dish.DishStatus = DishStatus.Deleted;
        //        await _dishRepository.Save(cancellationToken);
        //    }
        //    return new DeleteDishDTO.Response { IsSuccess = true };
        //}

        //public async Task<DeleteDishCategoryDTO.Response> DeleteDishCategory(Guid guid, CancellationToken cancellationToken)
        //{
        //    var category = await _dishCategoryRepository.FindById(guid, cancellationToken);
        //    if (category != null)
        //    {
        //        await _dishCategoryRepository.Delete(category, cancellationToken);
        //    }
        //    return new DeleteDishCategoryDTO.Response { IsSuccess = true };
        //}

        //public async Task<GetDishDTO.Response> GetDish(GetDishDTO.Request request, CancellationToken cancellationToken)
        //{
        //    var dish = await _dishRepository.FindById(request.Guid, cancellationToken);
        //    if (dish != null && dish.DishStatus != DishStatus.Deleted)
        //    {
        //        var dishDTO = _mapper.Map<DishDTO>(dish);
        //        dishDTO.Photo = await _storageService.GetPhotoURL(dish.Photo, cancellationToken);
        //        return new GetDishDTO.Response()
        //        {
        //            Dish = dishDTO,
        //            IsSuccess = true
        //        };
        //    }
        //    return new GetDishDTO.Response()
        //    {
        //        IsSuccess = false,
        //        ErrorMsg = "No such dish in DB"
        //    };
        //}

        //public async Task<GetDishCategoriesDTO.Response> GetDishCategories(CancellationToken cancellationToken)
        //{
        //    var categories = await _dishCategoryRepository.FindAll().ToListAsync();
            
        //    if (categories == null)
        //    {
        //        return new GetDishCategoriesDTO.Response()
        //        {
        //            IsSuccess = false,
        //            ErrorMsg = "Empty category list"
        //        };
        //    }
            
        //    var categoriesDTO = _mapper.Map<List<DishCategoryDTO>>(categories);

        //    return new GetDishCategoriesDTO.Response()
        //    {
        //        DishCategories = categoriesDTO,
        //        IsSuccess = true
        //    };
        //}

        //public async Task<GetDishCategoryDTO.Response> GetDishCategory(Guid guid, CancellationToken cancellationToken)
        //{
        //    var category = await _dishCategoryRepository.FindById(guid, cancellationToken);
        //    var categoryDTO = _mapper.Map<DishCategoryDTO>(category);

        //    if (categoryDTO == null)
        //    {
        //        return new GetDishCategoryDTO.Response()
        //        {
        //            IsSuccess = false,
        //            ErrorMsg = "No such category in DB"
        //        };
        //    }

        //    return new GetDishCategoryDTO.Response()
        //    {
        //        DishCategory = categoryDTO,
        //        IsSuccess = true
        //    };
        //}

        //public Task<UpdateDishDTO.Response> UpdateDish(UpdateDishDTO.Request request, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
