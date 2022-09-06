using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class liquids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discharges");

            migrationBuilder.DropTable(
                name: "Diuresises");

            migrationBuilder.DropTable(
                name: "Vomitings");

            migrationBuilder.CreateTable(
                name: "Liquids",
                columns: table => new
                {
                    LiquidsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vomiting = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Discharge = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Diuresis = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquids", x => x.LiquidsId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Liquids");

            migrationBuilder.CreateTable(
                name: "Discharges",
                columns: table => new
                {
                    DischargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discharges", x => x.DischargeId);
                });

            migrationBuilder.CreateTable(
                name: "Diuresises",
                columns: table => new
                {
                    DiuresisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diuresises", x => x.DiuresisId);
                });

            migrationBuilder.CreateTable(
                name: "Vomitings",
                columns: table => new
                {
                    VomitingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vomitings", x => x.VomitingId);
                });
        }
    }
}
