using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Repositories;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }
    [HttpGet]
    // Pega todos produtos: /api/products
    public async Task<ActionResult<IEnumerable<ProductDTO>>> get() 
    {
        var productsDTO = await _productService.getProducts();

        if(productsDTO is null)
            return NotFound("Products Not Found"); // 404

        return Ok(productsDTO); // 200
    }

    [HttpGet("{id:int}", Name = "getProductById")] // Name alias, podendo assim, utilizar em outro verbo
    // pega uma categoria pelo id: /api/products/{id:int} 
    public async Task<ActionResult<ProductDTO>> getProductById(int id) 
    {
        var productDTO = await _productService.getProductById(id);

        if(productDTO is null)
            return NotFound("Product by id: "+id+" Not Found"); // 404

        return Ok(productDTO); // 200
    }

    [HttpPost]
    // adiciona uma categoria e retorna o obj utilizando o alias definido a cima /\
    public async Task<ActionResult<ProductDTO>> post([FromBody] ProductDTO productDTO)
    {
        if (productDTO is null)
            return BadRequest("Invalid data"); // 400
        
        await _productService.addProduct(productDTO);

        return new CreatedAtRouteResult("getProductByID", new { id = productDTO.Id}, productDTO);
    } // 201 Created /\

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProductDTO>> put(int id, [FromBody] ProductDTO productDTO)
    {
        if (id != productDTO.Id|| productDTO is null)
            return BadRequest(); // 400
    
        await _productService.updateProduct(productDTO);

        return Ok(productDTO); // 200
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ProductDTO>> delete(int id)
    {
        var productDTO = await _productService.getProductById(id);

        if (productDTO is null)
            return NotFound("Product not found");

        await _productService.removeProductById(id);

        return Ok(productDTO);
    }
}