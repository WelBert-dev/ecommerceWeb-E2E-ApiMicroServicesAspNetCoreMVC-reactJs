using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class InsereProductRegTest : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (Nme, Price, Description, Stock, ImageURL, CategoryId, Brand, NumReviews, Rating) VALUES ('Pamonha', 1.50, 'Pamonha é gostosu', 1500, '/images/pamonha.jpg', 1, 'Nike', 125, 4.2), ('Paçoka', 2.50, 'Paçoka é gostosu', 1232, '/images/pacoka.jpg', 2, 'Abibas', 254, 3.5), ('Bolo de murango', 10.30, 'Bolo é gostosu', 1478, '/images/boluMurangu.jpg', 2, 'Irineu', 545, 5), ('GR6', 11.30, 'Detona funk', 1445, '/images/biriri.jpg', 3, 'WHEY', 254, 4.5);");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM products");
        }
    }
}
