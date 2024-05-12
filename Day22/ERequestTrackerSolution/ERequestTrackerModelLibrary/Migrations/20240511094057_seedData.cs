using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERequestTrackerModelLibrary.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 101, "Sai", "sai123", "Admin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 102, "Shiva", "shiva123", "Admin" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Password", "Role" },
                values: new object[] { 103, "Pavi", "pavi123", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 103);
        }
    }
}
