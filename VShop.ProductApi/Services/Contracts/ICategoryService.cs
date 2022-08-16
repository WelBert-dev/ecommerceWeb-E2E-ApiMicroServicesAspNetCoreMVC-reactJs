using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDTO>> getCategories();
    Task<IEnumerable<CategoryDTO>> getCategoriesProducts();
    Task<CategoryDTO> getCategoryById(int id);
    Task addCategory(CategoryDTO categoryDTO);
    Task updateCategory(CategoryDTO categoryDTO);
    Task removeCategoryById(int id);

}