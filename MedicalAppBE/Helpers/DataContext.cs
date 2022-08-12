using MedicalAppBE.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppBE.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("MedicalAppBEDatabase"));
        }

        public DbSet<Administering> Administerings { get; set; }
        public DbSet<Anamnesis> Anamnesiss { get; set; }
        public DbSet<Breath> Breaths { get; set; }
        public DbSet<ClinicalExamination> ClinicalExaminations { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Evolution> Evolutions { get; set; }
        public DbSet<Hospitalization> Hospitalizations { get; set; }
        public DbSet<IngestedFluid> IngestedFluids { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pulse> Pulses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TA> TAs { get; set; }
        public DbSet<Temperature> Temperatures { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Liquids> Liquids { get; set; }
        public DbSet<Ward> Wards { get; set; }

    }
}
