using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class InsereProductRegTestTest : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {            
            mb.Sql("INSERT INTO Products (Name, Price, Description, Stock, ImageURL, CategoryId, Brand, NumReviews, Rating) VALUES ('Piriri', 2.50, 'Pamonha é gostosu', 1458, '/images/pamon.jpg', 1, 'Nike', 144, 3.5), ('Pipipi', 5.50, 'Paçoka é gostosu', 1254, '/images/pacoka.jpg', 2, 'Irineu', 144, 5), ('Popopp', 147.30, 'Bolo é gostosu', 142, '/images/boluMurangu.jpg', 2, 'InemEu', 44, 3.5);");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM products");
        }
    }
}
