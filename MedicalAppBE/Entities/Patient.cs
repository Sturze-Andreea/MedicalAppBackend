using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName="nvarchar(13)")]
        public string CNP { get; set; }

        [Column(TypeName="date")]
        public DateTime DOB { get; set; }



    }
}
