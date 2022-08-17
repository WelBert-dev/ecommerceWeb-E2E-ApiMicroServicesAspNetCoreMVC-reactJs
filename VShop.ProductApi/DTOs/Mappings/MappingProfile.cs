using AutoMapper;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.DTOs.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CategoryModel, CategoryDTO>().ReverseMap();

        CreateMap<ProductModel, ProductDTO>();
        // Ao acrescentar mais um campo em DTO, e não em Model, devemos atribuir no mapeamento
        // p = Product
        CreateMap<ProductModel, ProductDTO>()
            .ForMember(p => p.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
    }
}