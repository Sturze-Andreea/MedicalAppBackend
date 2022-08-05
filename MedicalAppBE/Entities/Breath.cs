using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Breath
    {
        [Key]
        public int BreathId { get; set; }

        [Column(TypeName="int")]
        public int BreathNr { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime Date { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }
    }
}