using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService (IProductRepository productRepository, IMapper mapper)
    {
        this._productRepository = productRepository;
        this._mapper = mapper;
    }
    public async Task<IEnumerable<ProductDTO>> getProducts()
    {
        var productsEntity = await _productRepository.getAll();

        // converte [ENTITY] para [DTO]
        return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

    }
    public async Task<ProductDTO> getProductById(int id)
    {
        var productEntity = await _productRepository.getById(id);

        // converte [ENTITY] para [DTO]
        return _mapper.Map<ProductDTO>(productEntity);
    }
    public async Task addProduct(ProductDTO productDTO)
    {
        // converte [DTO] para [ENTITY] 
        var productEntity = _mapper.Map<ProductModel>(productDTO);

        await _productRepository.create(productEntity);

        // é necessário atribuir o id a entity pois no banco é AUTO_INCREMENT

        productDTO.Id = productEntity.Id;
    }
    public async Task updateProduct(ProductDTO productDTO)
    {
        // converte [DTO] para [ENTITY]
        var productEntity = _mapper.Map<ProductModel>(productDTO);

        await _productRepository.update(productEntity);
    }
    public async Task removeProductById(int id)
    {
        await _productRepository.delete(id);
    }
}