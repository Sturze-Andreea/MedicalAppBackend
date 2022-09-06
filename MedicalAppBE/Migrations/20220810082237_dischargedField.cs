using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class dischargedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Discharged",
                table: "Hospitalizations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discharged",
                table: "Hospitalizations");
        }
    }
}
