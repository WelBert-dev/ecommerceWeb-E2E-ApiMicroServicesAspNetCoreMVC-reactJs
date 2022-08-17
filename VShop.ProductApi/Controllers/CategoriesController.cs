using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        this._categoryService = categoryService;
    }
    [HttpGet]
    // Pega todas categorias: /api/categories
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> get() 
    {
        var categoriesDTO = await _categoryService.getCategories();

        if(categoriesDTO is null)
            return NotFound("Categories Not Found"); // 404

        return Ok(categoriesDTO); // 200
    }

    [HttpGet("products")]
    // pega todas categorias e produtos: /api/categories/products
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> getCategoriesProducts() 
    {
        var categoriesDTO = await _categoryService.getCategoriesProducts();

        if(categoriesDTO is null)
            return NotFound("Categories and Products Not Found"); // 404

        return Ok(categoriesDTO); // 200
    }

    [HttpGet("{id:int}", Name = "getCategoryById")] // Name alias, podendo assim, utilizar em outro verbo
    // pega uma categoria pelo id: /api/categories/{id:int} 
        public async Task<ActionResult<CategoryDTO>> getCategoryById(int id) 
    {
        var categoryDTO = await _categoryService.getCategoryById(id);

        if(categoryDTO is null)
            return NotFound("Category by id: "+id+" Not Found"); // 404

        return Ok(categoryDTO); // 200
    }

    [HttpPost]
    // adiciona uma categoria e retorna o obj utilizando o alias definido a cima /\
    public async Task<ActionResult<CategoryDTO>> post([FromBody] CategoryDTO categoryDTO)
    {
        if (categoryDTO is null)
            return BadRequest("Invalid data"); // 400
        
        await _categoryService.addCategory(categoryDTO);

        return new CreatedAtRouteResult("getCategoryByID", new { id = categoryDTO.CategoryId}, categoryDTO);
    } // 201 Created /\

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> put(int id, [FromBody] CategoryDTO categoryDTO)
    {
        if (id != categoryDTO.CategoryId || categoryDTO is null)
            return BadRequest(); // 400
    
        await _categoryService.updateCategory(categoryDTO);

        return Ok(categoryDTO); // 200
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoryDTO>> delete(int id)
    {
        var categoryDTO = await _categoryService.getCategoryById(id);

        if (categoryDTO is null)
            return NotFound("Category not found");

        await _categoryService.removeCategoryById(id);

        return Ok(categoryDTO);
    }

}