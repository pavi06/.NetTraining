using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustId);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    CustId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.CustId);
                    table.ForeignKey(
                        name: "FK_Users_Customers_CustId",
                        column: x => x.CustId,
                        principalTable: "Customers",
                        principalColumn: "CustId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Stock_Pizza_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizza",
                        principalColumn: "PizzaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "IsAvailable", "Name", "Price", "size" },
                values: new object[] { 101, "A classic Margherita pizza boasts a perfect harmony of tangy tomato sauce, creamy mozzarella, and fragrant basil on a crispy crust", true, "Margherita Pizza", 250.0, "Regular" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "IsAvailable", "Name", "Price", "size" },
                values: new object[] { 102, "A tantalizing fusion of gooey cheese and sweet corn kernels atop a golden crust, delivering a delightful blend of flavors in every bite.", true, "Cheese & Corn Pizza", 350.0, "Regular" });

            migrationBuilder.InsertData(
                table: "Pizza",
                columns: new[] { "PizzaId", "Description", "IsAvailable", "Name", "Price", "size" },
                values: new object[] { 103, "Indulge in smoky perfection with our barbecue chicken pizza, where every bite is a flavor-packed journey", false, "Barbecue chicken Pizza", 450.0, "Regular" });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_PizzaId",
                table: "Stock",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
