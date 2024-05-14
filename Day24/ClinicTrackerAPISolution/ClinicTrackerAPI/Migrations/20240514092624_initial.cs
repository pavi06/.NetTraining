using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicTrackerAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<double>(type: "float", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "Experience", "Name", "PhoneNumber", "Qualification", "Specialization" },
                values: new object[] { 101, 28, 3.0, "Sai", "9876543321", "MBBS, MD", "Cardialogists" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "Experience", "Name", "PhoneNumber", "Qualification", "Specialization" },
                values: new object[] { 102, 35, 8.0, "Shiva", "9988776655", "MBBS, MD", "Neurologists" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
