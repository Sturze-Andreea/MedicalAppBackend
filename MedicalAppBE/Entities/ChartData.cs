using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class ChartData
    {
 
        [Key]
        public int HospitalizationId { get; set; }


        [Column(TypeName = "int")]
        public int BreathNr { get; set; }
        [Column(TypeName = "int")]
        public int Pulse { get; set; }
        [Column(TypeName = "int")]
        public int MinTA { get; set; }

        [Column(TypeName = "int")]
        public int MaxTA { get; set; }
        [Column(TypeName = "float")]
        public float Temperature { get; set; }
        [Column(TypeName ="date")]
        public DateTime Date { get; set; }
    }
}