using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppBE.Entities
{
    public class PatientFromWard
    {
        [Key]
        public int PatientId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(13)")]
        public string CNP { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [ForeignKey("HospitalizationId")]
        public int HospitalizationId { get; set; }

        public virtual Hospitalization Hospitalization { get; set; }

        [ForeignKey("WardId")]
        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }

        [Column(TypeName = "date")]
        public DateTime HospitalizationDate { get; set; }

        [ForeignKey("UserId")]
        public int Doctor { get; set; }
        public virtual User User { get; set; }

        [Column(TypeName = "bit")]
        public bool Discharged { get; set; }

        [Column(TypeName = "int")]
        public int RoomNr { get; set; }

        [Column(TypeName = "int")]
        public int BedNr { get; set; }



    }
}
