using System.ComponentModel.DataAnnotations;

using VShop.ProductApi.Models;
namespace VShop.ProductApi.DTOs;

public class ProductDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome é Obrigatório!")]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "O Preço é Obrigatório!")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A Descrição é obrigatória!")]
    [MinLength(5)]
    [MaxLength(200)]
    public string? Description {get; set; }

    [Required(ErrorMessage = "A quantidade de estoque é obrigatório!")]
    [Range(1, 9999)]
    public long Stock { get; set; }
    public string? ImageURL {get; set; }

    public CategoryModel? Category {get; set; }
    public int CategoryId {get; set; }
}