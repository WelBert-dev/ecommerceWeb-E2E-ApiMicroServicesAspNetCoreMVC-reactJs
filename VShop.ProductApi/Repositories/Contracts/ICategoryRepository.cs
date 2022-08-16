using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public interface ICategoryRepository
{
    Task<IEnumerable<CategoryModel>> getAll();
    Task<IEnumerable<CategoryModel>> getCategoriesProducts();
    Task<CategoryModel> getById(int id);
    Task<CategoryModel> create(CategoryModel category);
    Task<CategoryModel> update(CategoryModel category);
    Task<CategoryModel> delete(int id);

}