using System.Collections.Generic;
using System.Linq;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFOpportunityRepository : IOpportunityRepository
    {
        private ApplicationDbContext context;

        public EFOpportunityRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }// end EFOpportunityRepository constructor

        public IEnumerable<Opportunity> Opportunity => context.Opportunities;


        public void SaveOpportunity(Opportunity opportunity)
        {
            
            if(opportunity.OPPORTUNITYID == 0)
            {
                context.Opportunities.Add(opportunity);
            }// end if(opportunity.OPPORTUNITYID == 0) check
            else
            {
                Opportunity dbEntry = context.Opportunities
                    .FirstOrDefault(opp => opp.OPPORTUNITYID == opportunity.OPPORTUNITYID);
                if(dbEntry != null)
                {
                    dbEntry.OpportunityName = opportunity.OpportunityName;
                    dbEntry.OpportunityDate = opportunity.OpportunityDate;
                    dbEntry.OpportunityStreet = opportunity.OpportunityStreet;
                    dbEntry.OpportunityCity = opportunity.OpportunityCity;
                    dbEntry.OpportunityCounty = opportunity.OpportunityCounty;
                    dbEntry.OpportunityState = opportunity.OpportunityState;
                    dbEntry.OpportunityZipCode = opportunity.OpportunityZipCode;
                    dbEntry.OpportunityElderSource = opportunity.OpportunityElderSource;
                    dbEntry.OpportunityElderSourceInstitute = opportunity.OpportunityElderSourceInstitute;
                    dbEntry.OpportunityNutrition = opportunity.OpportunityNutrition;
                    dbEntry.OpportunityTrainingFacilitator = opportunity.OpportunityTrainingFacilitator;
                    dbEntry.OpportunityAdmin = opportunity.OpportunityAdmin;
                    dbEntry.OpportunityGeneral = opportunity.OpportunityGeneral;
                    dbEntry.OpportunityHealthyLiving = opportunity.OpportunityHealthyLiving;
                    dbEntry.OpportunityDiseaseManagement = opportunity.OpportunityDiseaseManagement;
                    dbEntry.OpportunityFallsPrevention = opportunity.OpportunityFallsPrevention;
                    dbEntry.OpportunityCaregiver = opportunity.OpportunityCaregiver;
                    dbEntry.OpportunityMentalWellness = opportunity.OpportunityMentalWellness;
                    dbEntry.OpportunityEvents = opportunity.OpportunityEvents;
                    dbEntry.OpportunitySocialMedia = opportunity.OpportunitySocialMedia;
                    dbEntry.OpportunityOtherInterest = opportunity.OpportunityOtherInterest;
                    dbEntry.OpportunityDescription = opportunity.OpportunityDescription;
                }// end if(dbEntry != null) check
            }// end else
            context.SaveChanges();
            
        }// end SaveOpportunity method
    }// end EFOpportuintyRepository class
}// end ElderSourceVolunteerManagementCore.Models namespace
