namespace VShop.ProductApi.Context;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }

    public DbSet<CategoryModel> Categories {get; set; }
    
    public DbSet<ProductModel> Products {get; set; }

    // Fluent API 
}