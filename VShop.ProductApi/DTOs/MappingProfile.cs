using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryModel, CategoryDTO>().ReverseMap();
        CreateMap<ProductModel, ProductDTO>().ReverseMap();
    }
}