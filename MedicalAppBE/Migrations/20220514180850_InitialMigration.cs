using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administerings",
                columns: table => new
                {
                    AdministeringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frequency = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administerings", x => x.AdministeringId);
                });

            migrationBuilder.CreateTable(
                name: "Anamnesiss",
                columns: table => new
                {
                    AnamnesisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColateralAntecedents = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    LifeWorkConditions = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Behaviour = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PersonalAntecedents = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    BeforeMedication = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DiseaseHistory = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesiss", x => x.AnamnesisId);
                });

            migrationBuilder.CreateTable(
                name: "Breaths",
                columns: table => new
                {
                    BreathId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreathNr = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breaths", x => x.BreathId);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalExaminations",
                columns: table => new
                {
                    ClinicalExaminationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralCondition = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Behaviour = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Nutrition = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Consciousness = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RespiratorySystem = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CirculatorySystem = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    DigestiveTract = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalExaminations", x => x.ClinicalExaminationId);
                });

            migrationBuilder.CreateTable(
                name: "Discharges",
                columns: table => new
                {
                    DischargeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
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
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diuresises", x => x.DiuresisId);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AdministerWay = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "Evolutions",
                columns: table => new
                {
                    EvolutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evolutions", x => x.EvolutionId);
                });

            migrationBuilder.CreateTable(
                name: "Hospitalizations",
                columns: table => new
                {
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    RoomNr = table.Column<int>(type: "int", nullable: false),
                    BedNr = table.Column<int>(type: "int", nullable: false),
                    Doctor = table.Column<int>(type: "int", nullable: false),
                    Immobilized = table.Column<bool>(type: "bit", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Diet = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ContactPersonPhoneNr = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Dependecy = table.Column<int>(type: "int", nullable: false),
                    FallingRisk = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitalizations", x => x.HospitalizationId);
                });

            migrationBuilder.CreateTable(
                name: "IngestedFluids",
                columns: table => new
                {
                    IngestedFluidId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fluid = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngestedFluids", x => x.IngestedFluidId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CNP = table.Column<decimal>(type: "numeric(13)", nullable: false),
                    DOB = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Pulses",
                columns: table => new
                {
                    PulseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Puls = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pulses", x => x.PulseId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "TAs",
                columns: table => new
                {
                    TAId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Min = table.Column<int>(type: "int", nullable: false),
                    Max = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAs", x => x.TAId);
                });

            migrationBuilder.CreateTable(
                name: "Temperatures",
                columns: table => new
                {
                    TemperatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temp = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temperatures", x => x.TemperatureId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Vomitings",
                columns: table => new
                {
                    VomitingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    HospitalizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vomitings", x => x.VomitingId);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    WardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.WardId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administerings");

            migrationBuilder.DropTable(
                name: "Anamnesiss");

            migrationBuilder.DropTable(
                name: "Breaths");

            migrationBuilder.DropTable(
                name: "ClinicalExaminations");

            migrationBuilder.DropTable(
                name: "Discharges");

            migrationBuilder.DropTable(
                name: "Diuresises");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "Evolutions");

            migrationBuilder.DropTable(
                name: "Hospitalizations");

            migrationBuilder.DropTable(
                name: "IngestedFluids");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Pulses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TAs");

            migrationBuilder.DropTable(
                name: "Temperatures");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vomitings");

            migrationBuilder.DropTable(
                name: "Wards");
        }
    }
}
