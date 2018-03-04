using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFVolunteer2OpportunityHoursWorkedRepository : IVolunteer2OpportunityHoursWorkedRepository
    {
        private ApplicationDbContext context;

        public EFVolunteer2OpportunityHoursWorkedRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }// end EFVolunteer2OpportunityHoursWorkedRepository constructor

        public IEnumerable<Volunteer2OpportunityHoursWorked> Volunteer2OpportunityHoursWorked => context.Volunteer2OpprotunityHoursWorked;

        public void SaveVolunteer2OpportunityHoursWorked(Volunteer2OpportunityHoursWorked volunteer2OpportunityHoursWorked)
        {
            
            if (volunteer2OpportunityHoursWorked.VOLUNTEER2OPPORTUNITYHOURSWORKEDID == 0)
            {
                context.Volunteer2OpprotunityHoursWorked.Add(volunteer2OpportunityHoursWorked);
            }// end if(volunteer2OpportunityHoursWorked.VOLUTNEER2OPPOERUNITYHOURSWORKEDID == 0) check
            else
            {
                Volunteer2OpportunityHoursWorked dbEntry = context.Volunteer2OpprotunityHoursWorked
                    .FirstOrDefault(v2ohw => v2ohw.VOLUNTEER2OPPORTUNITYHOURSWORKEDID == volunteer2OpportunityHoursWorked.VOLUNTEER2OPPORTUNITYHOURSWORKEDID);
                if (dbEntry != null)
                {
                    dbEntry.Volunteer2Opportunity = volunteer2OpportunityHoursWorked.Volunteer2Opportunity;
                    dbEntry.VOLUNTEER2OPPORTUNITYID = volunteer2OpportunityHoursWorked.VOLUNTEER2OPPORTUNITYID;
                    dbEntry.HoursWorked = volunteer2OpportunityHoursWorked.HoursWorked;
                    dbEntry.DateWorked = volunteer2OpportunityHoursWorked.DateWorked;
                }// end dbEntry != null if check
            }// end else check
            context.SaveChanges();
            
        }// end SaveVolunteer2OpportunityHoursWorked method
    }// end EFVolunteer2OpportuintyHoursWorkedRepository class
}// end ElderSourceVolunteerManagementCore.Models namespace
