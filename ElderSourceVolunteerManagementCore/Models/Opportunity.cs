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
        public Boolean OpportunityNutrition { get; set; }
        public Boolean OpportunityTrainingFacilitator { get; set; }
        public Boolean OpportunityAdmin { get; set; }
        public Boolean OpportunityGeneral { get; set; }
        public Boolean OpportunityHealthyLiving { get; set; }
        public Boolean OpportunityDiseaseManagement { get; set; }
        public Boolean OpportunityFallsPrevention { get; set; }
        public Boolean OpportunityCaregiver { get; set; }
        public Boolean OpportunityMentalWellness { get; set; }
        public Boolean OpportunityEvents { get; set; }
        public Boolean OpportunitySocialMedia { get; set; }
        public string OpportunityOtherInterest { get; set; }
        public string OpportunityDescription { get; set; }
    }// end Opportunity class
}
