namespace VShop.ProductApi.Models;

public class ProductModel 
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description {get; set; }
    public long Stock { get; set; }
    public string? Brand {get; set; }
    public decimal Rating {get; set; }
    public int NumReviews {get; set;}
    public string? ImageURL {get; set; }
    public CategoryModel? Category {get; set; }
    public int CategoryId {get; set; }

}