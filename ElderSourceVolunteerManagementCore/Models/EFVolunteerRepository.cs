using System.Collections.Generic;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFVolunteerRepository : IVolunteerRepository
    {
        private ApplicationDbContext context;

        public EFVolunteerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Volunteer> Volunteer => context.Volunteers;
    }
}
