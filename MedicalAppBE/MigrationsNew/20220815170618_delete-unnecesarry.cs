using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.MigrationsNew
{
    public partial class deleteunnecesarry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administerings");

            migrationBuilder.DropTable(
                name: "IngestedFluids");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administerings",
                columns: table => new
                {
                    AdministeringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Frequency = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administerings", x => x.AdministeringId);
                    table.ForeignKey(
                        name: "FK_Administerings_Hospitalizations_HospitalizationId",
                        column: x => x.HospitalizationId,
                        principalTable: "Hospitalizations",
                        principalColumn: "HospitalizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngestedFluids",
                columns: table => new
                {
                    IngestedFluidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    Fluid = table.Column<double>(type: "float", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestedFluids", x => x.IngestedFluidId);
                    table.ForeignKey(
                        name: "FK_IngestedFluids_Hospitalizations_HospitalizationId",
                        column: x => x.HospitalizationId,
                        principalTable: "Hospitalizations",
                        principalColumn: "HospitalizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administerings_HospitalizationId",
                table: "Administerings",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestedFluids_HospitalizationId",
                table: "IngestedFluids",
                column: "HospitalizationId");
        }
    }
}
