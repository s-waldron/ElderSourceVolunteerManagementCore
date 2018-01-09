using System.ComponentModel.DataAnnotations;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }// end CreateModel class
    public class LoginModel
    {
        [Required]
        [UIHint("email")]
        public string Email { get; set; }
        
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }// end LoginModel class
}// end ElderSourceVolunteerManagementCore.Models.ViewModels namespace
