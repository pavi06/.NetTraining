using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ImageUrl", "Price", "ProductDescription", "ProductName" },
                values: new object[] { 101, "https://paviblobstorage.blob.core.windows.net/product-images/pencil.jpg", 10.050000000000001, "Wonderful Pencil with various shades available", "Pencil" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ImageUrl", "Price", "ProductDescription", "ProductName" },
                values: new object[] { 102, "https://paviblobstorage.blob.core.windows.net/product-images/colorPencil.jpg", 50.049999999999997, "Wonderful Color Pencils with 7 shades available", "Color Pencil" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ImageUrl", "Price", "ProductDescription", "ProductName" },
                values: new object[] { 103, "https://paviblobstorage.blob.core.windows.net/product-images/sketchPen.jpg", 150.05000000000001, "Wonderful Sketch Pens with 7 colors available", "Sketch Pens" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
