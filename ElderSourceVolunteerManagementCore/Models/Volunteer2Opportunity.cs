using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Volunteer2Opportunity
    {
        [Key]
        public int VOLUNTEER2OPPORTUNITYID { get; set; }
        [Required]
        public Volunteer VOLUNTEERID { get; set; }
        [Required]
        public Opportunity OPPORTUNITYID { get; set; }
        public int HoursWorked { get; set; }
    }
}
