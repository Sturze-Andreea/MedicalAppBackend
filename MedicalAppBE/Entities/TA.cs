using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class TA
    {
        [Key]
        public int TAId { get; set; }

        [Column(TypeName="int")]
        public int Min { get; set; }

        [Column(TypeName="int")]
        public int Max { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime Date { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }

        public virtual Hospitalization Hospitalization { get; set; }
    }
}