using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this._categoryRepository = categoryRepository;
        this._mapper = mapper;
    }
    public async Task<IEnumerable<CategoryDTO>> getCategories()
    {
        var categoriesEntity = await _categoryRepository.getAll();

        // converte [ENTITY] para [DTO]
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }
    public async Task<IEnumerable<CategoryDTO>> getCategoriesProducts()
    {
        var categoriesEntity = await _categoryRepository.getCategoriesProducts();

        // converte [ENTITY] para [DTO]
        return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
    }
    public async Task<CategoryDTO> getCategoryById(int id)
    {
        var categoryEntity = await _categoryRepository.getById(id);

        // converte [ENTITY] para [DTO]
        return _mapper.Map<CategoryDTO>(categoryEntity);
    }
    public async Task addCategory(CategoryDTO categoryDTO)
    {
        // converte [DTO] para [ENTITY]
        var categoryEntity = _mapper.Map<CategoryModel>(categoryDTO);

        await _categoryRepository.create(categoryEntity);

        // devemos setar o id pois no banco é AUTO_INCREMENT mas aqui não!!!
        categoryDTO.CategoryId = categoryEntity.CategoryId;


    }
    public async Task updateCategory(CategoryDTO categoryDTO)
    {
        // converte [DTO] para [ENTITY]
        var categoryEntity = _mapper.Map<CategoryModel>(categoryDTO);

        await _categoryRepository.update(categoryEntity);
    }
    public async Task removeCategoryById(int id)
    {       
        await _categoryRepository.delete(id);
    }
}