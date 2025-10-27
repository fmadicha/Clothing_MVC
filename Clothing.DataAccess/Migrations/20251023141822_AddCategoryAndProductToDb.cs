using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Clothing.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndProductToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ListPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Price50 = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Men's clothing collection", "Men" },
                    { 2, "Women's fashion and apparel", "Women" },
                    { 3, "Children's wear", "Kids" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Color", "Description", "ImageUrl", "ListPrice", "Name", "Price", "Price50", "Size", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Black", "Cotton slim-fit T-shirt", "/images/mens-tshirt.jpg", 249.99m, "Men’s T-Shirt", 229.99m, 209.99m, "M", 30 },
                    { 2, 2, "Blue", "Blue denim jacket with front pockets", "/images/womens-denim-jacket.jpg", 200.00m, "Women’s Denim Jacket", 180.00m, 160.00m, "L", 15 },
                    { 3, 3, "Red", "Warm fleece hoodie for kids", "/images/kids-hoodie.jpg", 249.99m, "Kids’ Hoodie", 229.99m, 209.99m, "S", 25 },
                    { 4, 1, "White", "White long-sleeve formal shirt", "/images/mens-formal-shirt.jpg", 299.99m, "Men’s Formal Shirt", 279.99m, 249.99m, "L", 20 },
                    { 5, 2, "Yellow", "Light floral dress for warm days", "/images/womens-dress.jpg", 349.99m, "Women’s Summer Dress", 329.99m, 309.99m, "M", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
