using System.ComponentModel.DataAnnotations;

namespace BloggieWebsite.Models.View_Model
{
    public class RegisterViewModelRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Must be at least 6 characters")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
