using System.Collections.Generic;

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
    }// end EFVolunteer2OpportunityRepository class
}// end ElderSourceVolunteerManagementCore.Models namespace
