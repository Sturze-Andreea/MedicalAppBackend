// <auto-generated />
using System;
using MedicalAppBE.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedicalAppBE.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220812165306_frequency")]
    partial class frequency
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicalAppBE.Entities.Administering", b =>
                {
                    b.Property<int>("AdministeringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.HasKey("AdministeringId");

                    b.ToTable("Administerings");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Anamnesis", b =>
                {
                    b.Property<int>("AnamnesisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BeforeMedication")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Behaviour")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ColateralAntecedents")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("DiseaseHistory")
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<string>("LifeWorkConditions")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PersonalAntecedents")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("AnamnesisId");

                    b.ToTable("Anamnesiss");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Breath", b =>
                {
                    b.Property<int>("BreathId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BreathNr")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.HasKey("BreathId");

                    b.ToTable("Breaths");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.ClinicalExamination", b =>
                {
                    b.Property<int>("ClinicalExaminationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Behaviour")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CirculatorySystem")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Consciousness")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DigestiveTract")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GeneralCondition")
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<string>("Nutrition")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RespiratorySystem")
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("ClinicalExaminationId");

                    b.ToTable("ClinicalExaminations");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Drug", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdministerWay")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Frequency")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("DrugId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Evolution", b =>
                {
                    b.Property<int>("EvolutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.HasKey("EvolutionId");

                    b.ToTable("Evolutions");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Hospitalization", b =>
                {
                    b.Property<int>("HospitalizationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Allergies")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BedNr")
                        .HasColumnType("int");

                    b.Property<string>("ContactPersonName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactPersonPhoneNr")
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("Dependecy")
                        .HasColumnType("int");

                    b.Property<string>("Diet")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Discharged")
                        .HasColumnType("bit");

                    b.Property<int>("Doctor")
                        .HasColumnType("int");

                    b.Property<string>("FallingRisk")
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("Immobilized")
                        .HasColumnType("bit");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("RoomNr")
                        .HasColumnType("int");

                    b.Property<int>("WardId")
                        .HasColumnType("int");

                    b.HasKey("HospitalizationId");

                    b.ToTable("Hospitalizations");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.IngestedFluid", b =>
                {
                    b.Property<int>("IngestedFluidId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<double>("Fluid")
                        .HasColumnType("float");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.HasKey("IngestedFluidId");

                    b.ToTable("IngestedFluids");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Liquids", b =>
                {
                    b.Property<int>("LiquidsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Discharge")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Diuresis")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<string>("Vomiting")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("LiquidsId");

                    b.ToTable("Liquids");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNP")
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PatientId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Pulse", b =>
                {
                    b.Property<int>("PulseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<int>("Puls")
                        .HasColumnType("int");

                    b.HasKey("PulseId");

                    b.ToTable("Pulses");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.TA", b =>
                {
                    b.Property<int>("TAId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.HasKey("TAId");

                    b.ToTable("TAs");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Temperature", b =>
                {
                    b.Property<int>("TemperatureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("HospitalizationId")
                        .HasColumnType("int");

                    b.Property<double>("Temp")
                        .HasColumnType("float");

                    b.HasKey("TemperatureId");

                    b.ToTable("Temperatures");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MedicalAppBE.Entities.Ward", b =>
                {
                    b.Property<int>("WardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("WardId");

                    b.ToTable("Wards");
                });
#pragma warning restore 612, 618
        }
    }
}
