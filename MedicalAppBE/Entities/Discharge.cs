using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Discharge
    {
        [Key]
        public int DischargeId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime Date { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }
    }
}