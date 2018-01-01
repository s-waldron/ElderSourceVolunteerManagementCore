using System.Collections.Generic;

namespace ElderSourceVolunteerManagementCore.Models
{
    public interface IOpportunityRepository
    {
        IEnumerable<Opportunity> Opportunity { get; }

        void SaveOpportunity(Opportunity opportunity);
    }
}
