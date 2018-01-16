using System.Collections.Generic;
using System.Linq;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFVolunteer2OpportunityRepository : IVolunteer2OpportunityRepository
    {
        private ApplicationDbContext context;

        public EFVolunteer2OpportunityRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }// end EFVolunteer2OpportunityRepository constructor

        public IEnumerable<Volunteer2Opportunity> Volunteer2Opportunity => context.Volunteer2Opportunities;

        public void SaveVolunteer2Opportunity(Volunteer2Opportunity volunteer2Opportunity)
        {
            if(volunteer2Opportunity.VOLUNTEER2OPPORTUNITYID == 0)
            {
                context.Volunteer2Opportunities.Add(volunteer2Opportunity);
            }
            else
            {
                Volunteer2Opportunity dbEntry = context.Volunteer2Opportunities
                    .FirstOrDefault(v2O => v2O.VOLUNTEER2OPPORTUNITYID == volunteer2Opportunity.VOLUNTEER2OPPORTUNITYID);
                if(dbEntry != null)
                {
                    dbEntry.HoursWorked = volunteer2Opportunity.HoursWorked;
                }
            }
            context.SaveChanges();
        }
    }// end EFVolunteer2OpportunityRepository class
}// end ElderSourceVolunteerManagementCore.Models namespace
