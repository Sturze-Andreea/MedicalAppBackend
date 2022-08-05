using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class cnp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNP",
                table: "Patients",
                type: "nvarchar(13)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(13)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "CNP",
                table: "Patients",
                type: "numeric(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");
        }
    }
}
