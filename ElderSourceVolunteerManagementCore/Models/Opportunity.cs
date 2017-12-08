using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Opportunity
    {
        public int OPPORTUNITYID { get; set; }
        public string OpportunityName { get; set; }
        public DateTime OpportunityDate { get; set; }
        public Boolean OpportunityElderSource { get; set; }
        public Boolean OpportunityElderSourceInstitute { get; set; }
        public string OpportunityInterest { get; set; }
        public string OpportunityDescription { get; set; }
    }// end Opportunity class
}
