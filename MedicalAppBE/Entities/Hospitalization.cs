using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MedicalAppBE.Entities
{
    public class Hospitalization
    {
        [Key]
        public int HospitalizationId { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; }

        [ForeignKey("WardId")]
        public int WardId { get; set; }

        [Column(TypeName ="date")]
        public DateTime Date { get; set; }

        [Column(TypeName="int")]
        public int RoomNr { get; set; }

        [Column(TypeName="int")]
        public int BedNr { get; set; }

        [ForeignKey("MedicalStaffId")]
        public int Doctor { get; set; }

        [Column(TypeName="bit")]
        public bool Immobilized { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Allergies { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string Diet { get; set; }

        [Column(TypeName="nvarchar(100)")]
        public string ContactPersonName { get; set; }

        [Column(TypeName="nvarchar(10)")]
        public string ContactPersonPhoneNr { get; set; }

        [Column(TypeName="int")]
        public int Dependecy { get; set; }

        [Column(TypeName="nvarchar(10)")]
        public string FallingRisk { get; set; }


        
    }
}
