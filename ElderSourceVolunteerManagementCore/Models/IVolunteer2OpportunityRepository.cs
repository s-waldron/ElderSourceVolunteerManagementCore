using System.Collections.Generic;

namespace ElderSourceVolunteerManagementCore.Models
{
    public interface IVolunteer2OpportunityRepository
    {
        IEnumerable<Volunteer2Opportunity> Volunteer2Opportunity { get; }
    }
}
