using System.ComponentModel.DataAnnotations;

namespace WADAPI.Models
{
    public class Users
    {
        [Key] public int UserId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }    
        [Required(ErrorMessage = "Email name is required")]
        public string Email { get; set; }
        [Required, MinLength(6, ErrorMessage = "Password must be at least 6 character length")]
        public string Password { get; set; }
    }
}
