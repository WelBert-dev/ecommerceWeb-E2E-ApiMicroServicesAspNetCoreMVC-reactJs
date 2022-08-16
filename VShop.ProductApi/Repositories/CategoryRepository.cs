using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _contextRepository;
    public CategoryRepository(AppDbContext contextRepository)
    {
        this._contextRepository = contextRepository;
    }
    public async Task<IEnumerable<CategoryModel>> getAll()
    {
        return await _contextRepository.Categories.ToListAsync(); // N utilizar em produção
    }
    public async Task<IEnumerable<CategoryModel>> getCategoriesProducts()
    {
        return await _contextRepository.Categories.Include(c => c.Products).ToListAsync();
    }
    public async Task<CategoryModel> getById(int id)
    {
        // First async pois só pode retornar 1 val.
        return await _contextRepository.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();
    }
    public async Task<CategoryModel> create(CategoryModel category)
    {
        _contextRepository.Categories.Add(category);
        await _contextRepository.SaveChangesAsync(); // Reposiroty n deve persistir! n utilizar em produção
        return category;
    }
    public async Task<CategoryModel> update(CategoryModel category)
    {
        _contextRepository.Entry(category).State = EntityState.Modified;
        await _contextRepository.SaveChangesAsync();
        return category;
    }
    public async Task<CategoryModel> delete(int id)
    {
        var product = await getById(id);
        _contextRepository.Remove(product);
        await _contextRepository.SaveChangesAsync();
        return product;
    }
}