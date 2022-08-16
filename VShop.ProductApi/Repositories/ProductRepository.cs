using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _contextRepository;
    public ProductRepository (AppDbContext contextRepository)
    {
        _contextRepository = contextRepository;
    }
    public async Task<IEnumerable<ProductModel>> getAll()
    {
        // return await _contextRepository.Products.ToListAsync(); // N utilizar em produção
        return await _contextRepository.Products.ToListAsync();
    }
    public async Task<ProductModel> getById(int id)
    {
        // First async pois só pode retornar 1 val.
        return await _contextRepository.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
    }
    public async Task<ProductModel> create(ProductModel product)
    {
        _contextRepository.Products.Add(product);
        await _contextRepository.SaveChangesAsync(); // Reposiroty n deve persistir! n utilizar em produção
        return product;
    }
    public async Task<ProductModel> update(ProductModel product)
    {
        _contextRepository.Entry(product).State = EntityState.Modified;
        await _contextRepository.SaveChangesAsync();
        return product;
    }
    public async Task<ProductModel> delete(int id)
    {
        var product = await getById(id);
        _contextRepository.Remove(product);
        await _contextRepository.SaveChangesAsync();
        return product;
    }
}