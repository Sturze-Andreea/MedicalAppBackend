using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class cnp1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNP",
                table: "Patients",
                type: "nvarchar(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNP",
                table: "Patients",
                type: "nvarchar(13)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldNullable: true);
        }
    }
}
