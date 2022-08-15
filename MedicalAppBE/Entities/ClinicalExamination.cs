using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class ClinicalExamination
    {
        [Key]
        public int ClinicalExaminationId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string GeneralCondition { get; set; }

        [Column(TypeName="float")]
        public float Height { get; set; }

        [Column(TypeName="float")]
        public float Weight { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string Behaviour { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Nutrition { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Consciousness { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string RespiratorySystem { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string CirculatorySystem { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string DigestiveTract { get; set; }
        
        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }

        public virtual Hospitalization Hospitalization { get; set; }
    }
}