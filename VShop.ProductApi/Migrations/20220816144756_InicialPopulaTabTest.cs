using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class InicialPopulaTabTest : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categories (Name) VALUES ('Macoratti'), ('Irineu'), ('InemEu');");
            
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageURL, CategoryId) VALUES ('Pamonha', 1.50, 'Pamonha é gostosu', 1500, '/images/pamonha.jpg', 1), ('Paçoka', 2.50, 'Paçoka é gostosu', 1232, '/images/pacoka.jpg', 2), ('Bolo de murango', 10.30, 'Bolo é gostosu', 1478, '/images/boluMurangu.jpg', 2);");

        }
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM products");
        }
    }
}
