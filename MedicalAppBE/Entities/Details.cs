using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Details
    {
        [Key]
        public int HospitalizationId { get; set; }


        [Column(TypeName = "int")]
        public int BreathNr { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string DischargeDescription { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string DiuresisDescription { get; set; }
        [Column(TypeName = "float")]
        public float Fluid { get; set; }
        [Column(TypeName = "int")]
        public int Pulse { get; set; }
        [Column(TypeName = "int")]
        public int MinTA { get; set; }

        [Column(TypeName = "int")]
        public int MaxTA { get; set; }
        [Column(TypeName = "float")]
        public float Temperature { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string VomitingDescription { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string EvolutionDescription { get; set; }
    }
}
