using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }
    }// end Volunteer2Opportunity class
}// end ElderSourceVolunteerManagementCore.Models namespace
