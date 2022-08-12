using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Liquids
    {
        [Key]
        public int LiquidsId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Vomiting { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string Discharge { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string Diuresis { get; set; }

        [Column(TypeName="datetime2(7)")]
        public DateTime Date { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }
    }
}