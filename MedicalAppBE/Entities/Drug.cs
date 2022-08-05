using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Drug
    {
        [Key]
        public int DrugId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string AdministerWay { get; set; }
    }
}