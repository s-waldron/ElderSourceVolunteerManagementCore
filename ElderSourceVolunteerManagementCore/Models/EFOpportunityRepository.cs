using System.Collections.Generic;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFOpportunityRepository : IOpportunityRepository
    {
        private ApplicationDbContext context;

        public EFOpportunityRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Opportunity> Opportunity => context.Opportunities;
    }
}
