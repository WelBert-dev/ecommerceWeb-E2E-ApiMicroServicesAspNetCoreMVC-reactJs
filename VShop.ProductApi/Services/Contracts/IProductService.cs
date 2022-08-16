using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> getProducts();
    Task<ProductDTO> getProductById(int id);
    Task addProduct(ProductDTO productDTO);
    Task updateProduct(ProductDTO productDTo);
    Task removeProductById(int id);
}