using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class Volunteer2OpportunityViewModel
    {
        public Volunteer Volunteer { get; set; }
        public Opportunity Opportunity { get; set; }
        public IEnumerable<Opportunity> OpportunityList { get; set; }
        public int VOLUNTEERID { get; set; }
        public int OPPORTUNITYID { get; set; }
        
    }
}
