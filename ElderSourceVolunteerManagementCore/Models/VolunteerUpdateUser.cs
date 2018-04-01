using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class VolunteerUpdateUser
    {
        [Key]
        public int VOLUNTEERUPDATEUSERID { get; set; }
        [ForeignKey ("Volunteers")]
        public int VOLUNTEERID { get; set; }
        public Volunteer Volunteer { get; set; }
        public string UserName { get; set; }
        public DateTime DateUpdated { get; set; }
        //public List<Volunteer> Volunteers { get; set; }
    }// end VOlunteerUpdateUser class
}// end ElderSourceVolunteerManagementCore.Models namespace
