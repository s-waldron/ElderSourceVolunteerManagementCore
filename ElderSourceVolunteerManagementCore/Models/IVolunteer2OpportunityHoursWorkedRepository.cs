using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    interface IVolunteer2OpportunityHoursWorkedRepository
    {
        IEnumerable<Volunteer2OpportunityHoursWorked> Volunteer2OpportunityHoursWorked { get; }

        void SaveVolunteer2OpportunityHoursWorked(Volunteer2OpportunityHoursWorked volunteer2OpportunityHoursWorked);
    }
}
