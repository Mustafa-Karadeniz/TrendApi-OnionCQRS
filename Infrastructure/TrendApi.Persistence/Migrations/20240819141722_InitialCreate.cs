using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrendApi.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Brands",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Brands", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ParentId = table.Column<int>(type: "int", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Priorty = table.Column<int>(type: "int", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                BrandId = table.Column<int>(type: "int", nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
                table.ForeignKey(
                    name: "FK_Products_Brands_BrandId",
                    column: x => x.BrandId,
                    principalTable: "Brands",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Details",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                CategoryId = table.Column<int>(type: "int", nullable: false),
                CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Details", x => x.Id);
                table.ForeignKey(
                    name: "FK_Details_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "CategoryProduct",
            columns: table => new
            {
                CategoriesId = table.Column<int>(type: "int", nullable: false),
                ProductsId = table.Column<int>(type: "int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                table.ForeignKey(
                    name: "FK_CategoryProduct_Categories_CategoriesId",
                    column: x => x.CategoriesId,
                    principalTable: "Categories",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_CategoryProduct_Products_ProductsId",
                    column: x => x.ProductsId,
                    principalTable: "Products",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Brands",
            columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name" },
            values: new object[,]
            {
                { 1, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(2189), false, "Grocery & Games" },
                { 2, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(2203), false, "Jewelery" },
                { 3, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(2284), true, "Computers & Grocery" }
            });

        migrationBuilder.InsertData(
            table: "Categories",
            columns: new[] { "Id", "CreatedDate", "IsDeleted", "Name", "ParentId", "Priorty" },
            values: new object[,]
            {
                { 1, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5343), false, "Elektrik", 0, 1 },
                { 2, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5346), false, "Moda", 0, 2 },
                { 3, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5349), false, "Bilgisayar", 1, 1 },
                { 4, new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5352), false, "Kadın", 2, 1 }
            });

        migrationBuilder.InsertData(
            table: "Details",
            columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsDeleted", "Title" },
            values: new object[,]
            {
                { 1, 1, new DateTime(2024, 8, 19, 17, 17, 21, 633, DateTimeKind.Local).AddTicks(8167), "Quam oldular doğru değerli domates teldeki.\nNisi cezbelendi koştum için.\nEsse voluptatem esse kulu okuma olduğu çorba lambadaki ratione bilgiyasayarı.\nEve sed ex.\nVoluptatem aut doğru gidecekmiş et.", false, "Veritatis eos aliquid adresini." },
                { 2, 3, new DateTime(2024, 8, 19, 17, 17, 21, 633, DateTimeKind.Local).AddTicks(8410), "Adipisci beğendim duyulmamış.\nİçin eum sandalye adanaya ötekinden nemo.\nTotam nisi laudantium cezbelendi adresini voluptatem quaerat veniam esse sıradanlıktan.", false, "Balıkhaneye çünkü minima alias.\nVoluptatem ab deleniti." },
                { 3, 4, new DateTime(2024, 8, 19, 17, 17, 21, 633, DateTimeKind.Local).AddTicks(8661), "Reprehenderit sed adanaya quaerat magni.\nEt ad filmini velit bahar çarpan.\nArchitecto bundan sıla.\nİn inventore orta.", false, "Exercitationem ut quia türemiş camisi nihil domates consequatur.\nQuaerat aut aspernatur değerli iure çobanın gidecekmiş.\nSed batarya sarmal." }
            });

        migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Id", "BrandId", "CreatedDate", "Description", "Discount", "IsDeleted", "Price", "Title" },
            values: new object[,]
            {
                { 1, 1, new DateTime(2024, 8, 19, 17, 17, 21, 636, DateTimeKind.Local).AddTicks(8788), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 0.5762999020171780m, false, 61.12m, "Incredible Soft Towels" },
                { 2, 3, new DateTime(2024, 8, 19, 17, 17, 21, 636, DateTimeKind.Local).AddTicks(8832), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 5.783738445319780m, false, 594.22m, "Sleek Plastic Fish" }
            });

        migrationBuilder.CreateIndex(
            name: "IX_CategoryProduct_ProductsId",
            table: "CategoryProduct",
            column: "ProductsId");

        migrationBuilder.CreateIndex(
            name: "IX_Details_CategoryId",
            table: "Details",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_Products_BrandId",
            table: "Products",
            column: "BrandId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CategoryProduct");

        migrationBuilder.DropTable(
            name: "Details");

        migrationBuilder.DropTable(
            name: "Products");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Brands");
    }
}
