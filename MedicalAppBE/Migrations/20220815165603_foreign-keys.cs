using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalAppBE.Migrations
{
    public partial class foreignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hospitalizations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Temperatures_HospitalizationId",
                table: "Temperatures",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_TAs_HospitalizationId",
                table: "TAs",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pulses_HospitalizationId",
                table: "Pulses",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Liquids_HospitalizationId",
                table: "Liquids",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_IngestedFluids_HospitalizationId",
                table: "IngestedFluids",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_PatientId",
                table: "Hospitalizations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_UserId",
                table: "Hospitalizations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitalizations_WardId",
                table: "Hospitalizations",
                column: "WardId");

            migrationBuilder.CreateIndex(
                name: "IX_Evolutions_HospitalizationId",
                table: "Evolutions",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Drugs_HospitalizationId",
                table: "Drugs",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicalExaminations_HospitalizationId",
                table: "ClinicalExaminations",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Breaths_HospitalizationId",
                table: "Breaths",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Anamnesiss_HospitalizationId",
                table: "Anamnesiss",
                column: "HospitalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Administerings_HospitalizationId",
                table: "Administerings",
                column: "HospitalizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Administerings_Hospitalizations_HospitalizationId",
                table: "Administerings",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Anamnesiss_Hospitalizations_HospitalizationId",
                table: "Anamnesiss",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breaths_Hospitalizations_HospitalizationId",
                table: "Breaths",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClinicalExaminations_Hospitalizations_HospitalizationId",
                table: "ClinicalExaminations",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drugs_Hospitalizations_HospitalizationId",
                table: "Drugs",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Evolutions_Hospitalizations_HospitalizationId",
                table: "Evolutions",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalizations_Patients_PatientId",
                table: "Hospitalizations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalizations_Users_UserId",
                table: "Hospitalizations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitalizations_Wards_WardId",
                table: "Hospitalizations",
                column: "WardId",
                principalTable: "Wards",
                principalColumn: "WardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngestedFluids_Hospitalizations_HospitalizationId",
                table: "IngestedFluids",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Liquids_Hospitalizations_HospitalizationId",
                table: "Liquids",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pulses_Hospitalizations_HospitalizationId",
                table: "Pulses",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TAs_Hospitalizations_HospitalizationId",
                table: "TAs",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temperatures_Hospitalizations_HospitalizationId",
                table: "Temperatures",
                column: "HospitalizationId",
                principalTable: "Hospitalizations",
                principalColumn: "HospitalizationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Administerings_Hospitalizations_HospitalizationId",
                table: "Administerings");

            migrationBuilder.DropForeignKey(
                name: "FK_Anamnesiss_Hospitalizations_HospitalizationId",
                table: "Anamnesiss");

            migrationBuilder.DropForeignKey(
                name: "FK_Breaths_Hospitalizations_HospitalizationId",
                table: "Breaths");

            migrationBuilder.DropForeignKey(
                name: "FK_ClinicalExaminations_Hospitalizations_HospitalizationId",
                table: "ClinicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_Drugs_Hospitalizations_HospitalizationId",
                table: "Drugs");

            migrationBuilder.DropForeignKey(
                name: "FK_Evolutions_Hospitalizations_HospitalizationId",
                table: "Evolutions");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalizations_Patients_PatientId",
                table: "Hospitalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalizations_Users_UserId",
                table: "Hospitalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitalizations_Wards_WardId",
                table: "Hospitalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_IngestedFluids_Hospitalizations_HospitalizationId",
                table: "IngestedFluids");

            migrationBuilder.DropForeignKey(
                name: "FK_Liquids_Hospitalizations_HospitalizationId",
                table: "Liquids");

            migrationBuilder.DropForeignKey(
                name: "FK_Pulses_Hospitalizations_HospitalizationId",
                table: "Pulses");

            migrationBuilder.DropForeignKey(
                name: "FK_TAs_Hospitalizations_HospitalizationId",
                table: "TAs");

            migrationBuilder.DropForeignKey(
                name: "FK_Temperatures_Hospitalizations_HospitalizationId",
                table: "Temperatures");

            migrationBuilder.DropIndex(
                name: "IX_Temperatures_HospitalizationId",
                table: "Temperatures");

            migrationBuilder.DropIndex(
                name: "IX_TAs_HospitalizationId",
                table: "TAs");

            migrationBuilder.DropIndex(
                name: "IX_Pulses_HospitalizationId",
                table: "Pulses");

            migrationBuilder.DropIndex(
                name: "IX_Liquids_HospitalizationId",
                table: "Liquids");

            migrationBuilder.DropIndex(
                name: "IX_IngestedFluids_HospitalizationId",
                table: "IngestedFluids");

            migrationBuilder.DropIndex(
                name: "IX_Hospitalizations_PatientId",
                table: "Hospitalizations");

            migrationBuilder.DropIndex(
                name: "IX_Hospitalizations_UserId",
                table: "Hospitalizations");

            migrationBuilder.DropIndex(
                name: "IX_Hospitalizations_WardId",
                table: "Hospitalizations");

            migrationBuilder.DropIndex(
                name: "IX_Evolutions_HospitalizationId",
                table: "Evolutions");

            migrationBuilder.DropIndex(
                name: "IX_Drugs_HospitalizationId",
                table: "Drugs");

            migrationBuilder.DropIndex(
                name: "IX_ClinicalExaminations_HospitalizationId",
                table: "ClinicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_Breaths_HospitalizationId",
                table: "Breaths");

            migrationBuilder.DropIndex(
                name: "IX_Anamnesiss_HospitalizationId",
                table: "Anamnesiss");

            migrationBuilder.DropIndex(
                name: "IX_Administerings_HospitalizationId",
                table: "Administerings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hospitalizations");
        }
    }
}
