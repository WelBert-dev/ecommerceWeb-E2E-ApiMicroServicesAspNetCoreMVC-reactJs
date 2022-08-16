using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context; 

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) { }

    public DbSet<CategoryModel> Categories {get; set; }
    
    public DbSet<ProductModel> Products {get; set; }

    // Fluent API 

    protected override void OnModelCreating(ModelBuilder mb)
    {
        // category entity
        // id
        mb.Entity<CategoryModel>().HasKey(c => c.CategoryId);
        mb.Entity<CategoryModel>().
            Property(c => c.Name).
                HasMaxLength(100).
                    IsRequired();

        // product entity
        // name
        mb.Entity<ProductModel>().
            Property(p => p.Name).
                HasMaxLength(100).
                    IsRequired();
        // description
        mb.Entity<ProductModel>().
            Property(p => p.Description).
                HasMaxLength(255).
                    IsRequired();    
        // imageURL
        mb.Entity<ProductModel>().
            Property(p => p.ImageURL).
                HasMaxLength(255).
                    IsRequired();      
        // price
        mb.Entity<ProductModel>().
            Property(p => p.Price).
                HasPrecision(12, 2);

        // Define o relacionamento 1 para muitos
        mb.Entity<CategoryModel>().
            HasMany(g => g.Products).
                WithOne(c => c.Category).
                    IsRequired().
                        OnDelete(DeleteBehavior.Cascade); // ao excluir uma categoria, os produtos serão
                                                         //  excluidos em cascata
                                                        // outros parametros:
                                                       // SetNull....

        // Verifica se não possui dados iniciais e faz o insert
        mb.Entity<CategoryModel>().HasData(
            new CategoryModel
            {
                CategoryId = 1,
                Name = "Material Escolar"
            },
            new CategoryModel
            {
                CategoryId = 2,
                Name = "Acessórios"
            }
        );
    }
}