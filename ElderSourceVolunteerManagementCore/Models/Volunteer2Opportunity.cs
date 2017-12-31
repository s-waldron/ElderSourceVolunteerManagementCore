using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Volunteer2Opportunity
    {
        [Key]
        public int VOLUNTEER2OPPORTUNITYID { get; set; }
        [ForeignKey("Volunteer")]
        [Required]
        public int VOLUNTEERID { get; set; }
        [ForeignKey("Opportunity")]
        [Required]
        public int OPPORTUNITYID { get; set; }
        public int HoursWorked { get; set; }
    }
}
