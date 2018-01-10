using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

    public class RoleEditModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AppUsers> Members { get; set; }
        public IEnumerable<AppUsers> NonMembers { get; set; }
    }// end RoleEditModel class

    public class RoleModificationModel
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }// end RoleModifivationModel class
}// end ElderSourceVolunteerManagementCore.Models.ViewModels namespace
