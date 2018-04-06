using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Volunteer2OpportunityHoursWorked
    {
        [Key]
        public int VOLUNTEER2OPPORTUNITYHOURSWORKEDID { get; set; }
        [ForeignKey ("Volunteer2Opportunity")]
        public int VOLUNTEER2OPPORTUNITYID { get; set; }
        public Volunteer2Opportunity Volunteer2Opportunity { get; set; }
        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }
        public int HoursWorked { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateWorked { get; set; }
    }// end Volunteer2OpportunityHoursWorked class
}// end ElderSourceVolunteerManagementCore.Models namespace
