using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Administering
    {
        [Key]
        public int AdministeringId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Frequency { get; set; }

        [Column(TypeName="date")]
        public DateTime Date { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }
    }
}