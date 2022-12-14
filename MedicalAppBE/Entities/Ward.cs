using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppBE.Entities
{
    public class Ward
    {
        [Key]
        public int WardId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName="nvarchar(200)")]
        public string Description { get; set; }
    }
}
