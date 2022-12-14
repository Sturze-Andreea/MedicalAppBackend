using System.ComponentModel.DataAnnotations;

namespace MedicalAppBE.Models.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}