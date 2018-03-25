using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class Volunteer2OpportunityUpdateHoursViewModel
    {
        public Volunteer Volunteer { get; set; }
        public IEnumerable<Volunteer2Opportunity> Volunteer2OpportunityList { get; set; }
        public IEnumerable<Opportunity> OpportunityList { get; set; }
        public Volunteer2Opportunity Volunteer2Opportunity { get; set; }
        public int Hours { get; set; }
        public DateTime DateWorked { get; set; }
    }// end Volunteer2OpportunityUpdateHoursViewModel
}// end ElderSourceVolunteerManagementCore.Models.ViewModels namespace
