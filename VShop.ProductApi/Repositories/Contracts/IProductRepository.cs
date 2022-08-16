using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<ProductModel>> getAll();
    Task<ProductModel> getById(int id);
    Task<ProductModel> create(ProductModel product);
    Task<ProductModel> update(ProductModel product);
    Task<ProductModel> delete(int id);
}