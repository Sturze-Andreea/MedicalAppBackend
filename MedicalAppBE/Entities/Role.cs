using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalAppBE.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Name { get; set; }
    }
}
