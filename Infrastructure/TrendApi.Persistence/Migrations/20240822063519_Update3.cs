using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrendApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 700, DateTimeKind.Local).AddTicks(9322), "Computers" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 700, DateTimeKind.Local).AddTicks(9395), "Beauty & Shoes" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 700, DateTimeKind.Local).AddTicks(9429), "Kids, Health & Clothing" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 704, DateTimeKind.Local).AddTicks(3363), "Açılmadan değirmeni aut autem incidunt açılmadan bilgisayarı.\nİpsum quae bahar corporis.\nSokaklarda balıkhaneye sıradanlıktan aut anlamsız.\nOdio bilgisayarı okuma.\nDüşünüyor suscipit amet un telefonu.", "Autem magnam commodi çobanın." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 704, DateTimeKind.Local).AddTicks(3632), "Değerli ad sokaklarda fugit uzattı doğru ab numquam cezbelendi ab.\nRatione incidunt camisi voluptatem yaptı.\nQuam voluptatem patlıcan yaptı quia çakıl quia.", "Dağılımı dışarı tv incidunt et.\nDüşünüyor dışarı düşünüyor ab mıknatıslı dolayı sevindi rem gülüyorum umut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 704, DateTimeKind.Local).AddTicks(3890), "Mi yapacakmış sokaklarda çorba in.\nEnim quae filmini esse otobüs sed.\nUllam göze voluptate amet eum.\nMıknatıslı eum quis.", "Açılmadan masaya ea enim explicabo sequi çakıl quia odio.\nCorporis ex dergi odit ab koyun çarpan.\nMolestiae telefonu lakin voluptatem doğru duyulmamış otobüs ea." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 708, DateTimeKind.Local).AddTicks(4756), 2.126125070177150m, 195.21m, "Unbranded Wooden Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 22, 9, 35, 18, 708, DateTimeKind.Local).AddTicks(4811), "The Football Is Good For Training And Recreational Purposes", 5.3361974229110m, 528.70m, "Intelligent Plastic Chips" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

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

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(2189), "Grocery & Games" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(2203), "Jewelery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Name" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(2284), "Computers & Grocery" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2024, 8, 19, 17, 17, 21, 630, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 633, DateTimeKind.Local).AddTicks(8167), "Quam oldular doğru değerli domates teldeki.\nNisi cezbelendi koştum için.\nEsse voluptatem esse kulu okuma olduğu çorba lambadaki ratione bilgiyasayarı.\nEve sed ex.\nVoluptatem aut doğru gidecekmiş et.", "Veritatis eos aliquid adresini." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 633, DateTimeKind.Local).AddTicks(8410), "Adipisci beğendim duyulmamış.\nİçin eum sandalye adanaya ötekinden nemo.\nTotam nisi laudantium cezbelendi adresini voluptatem quaerat veniam esse sıradanlıktan.", "Balıkhaneye çünkü minima alias.\nVoluptatem ab deleniti." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 633, DateTimeKind.Local).AddTicks(8661), "Reprehenderit sed adanaya quaerat magni.\nEt ad filmini velit bahar çarpan.\nArchitecto bundan sıla.\nİn inventore orta.", "Exercitationem ut quia türemiş camisi nihil domates consequatur.\nQuaerat aut aspernatur değerli iure çobanın gidecekmiş.\nSed batarya sarmal." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 636, DateTimeKind.Local).AddTicks(8788), 0.5762999020171780m, 61.12m, "Incredible Soft Towels" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 8, 19, 17, 17, 21, 636, DateTimeKind.Local).AddTicks(8832), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", 5.783738445319780m, 594.22m, "Sleek Plastic Fish" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
