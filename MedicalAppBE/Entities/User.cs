using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace MedicalAppBE.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName="nvarchar(100)")]
        [JsonIgnore]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}
