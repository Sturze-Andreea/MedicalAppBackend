using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class IngestedFluid
    {
        [Key]
        public int IngestedFluidId { get; set; }

        [Column(TypeName="float")]
        public float Fluid { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime Date { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }
    }
}