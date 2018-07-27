using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Volunteer2Opportunity
    {
        [Key]
        public int VOLUNTEER2OPPORTUNITYID { get; set; }
        [ForeignKey("Volunteers")]
        [Required]
        public int VOLUNTEERID { get; set; }
        [ForeignKey("Opportunities")]
        [Required]
        public int OPPORTUNITYID { get; set; }
        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }
        
        //public List<Volunteer> Volunteers { get; set; }
        //public List<Opportunity> Opportunities { get; set; }
    }// end Volunteer2Opportunity class
}// end ElderSourceVolunteerManagementCore.Models namespace
