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

            if (volunteer2Opportunity.VOLUNTEER2OPPORTUNITYID == 0)
            {
                context.Volunteer2Opportunities.Add(volunteer2Opportunity);
            }// end if(volunteer.VOLUNTEERID == 0) check
            else
            {
                Volunteer2Opportunity dbEntry = context.Volunteer2Opportunities
                    .FirstOrDefault(v2o => v2o.VOLUNTEER2OPPORTUNITYID == volunteer2Opportunity.VOLUNTEER2OPPORTUNITYID);
                if (dbEntry != null)
                {
                    dbEntry.Volunteer = volunteer2Opportunity.Volunteer;
                    dbEntry.Opportunity = volunteer2Opportunity.Opportunity;
                    dbEntry.OPPORTUNITYID = volunteer2Opportunity.OPPORTUNITYID;
                    dbEntry.VOLUNTEERID = volunteer2Opportunity.VOLUNTEERID;
                }// end dbEntry != null if check
            }// end else check
            context.SaveChanges();
        }// end SaveVolunteer2Opportunity method
    }// end EFVolunteer2OpportunityRepository class
}// end ElderSourceVolunteerManagementCore.Models namespace
