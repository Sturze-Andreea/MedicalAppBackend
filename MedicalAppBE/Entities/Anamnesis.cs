using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Anamnesis
    {
        [Key]
        public int AnamnesisId { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string ColateralAntecedents { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string LifeWorkConditions { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string Behaviour { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string PersonalAntecedents { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string BeforeMedication { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string DiseaseHistory { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }
    }
}