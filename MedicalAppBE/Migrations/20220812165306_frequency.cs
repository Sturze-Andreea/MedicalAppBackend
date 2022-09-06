using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class frequency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Frequency",
                table: "Drugs",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HospitalizationId",
                table: "Drugs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frequency",
                table: "Drugs");

            migrationBuilder.DropColumn(
                name: "HospitalizationId",
                table: "Drugs");
        }
    }
}
