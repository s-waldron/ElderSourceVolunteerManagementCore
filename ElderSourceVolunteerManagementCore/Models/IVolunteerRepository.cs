using System.Collections.Generic;

namespace ElderSourceVolunteerManagementCore.Models
{
    public interface IVolunteerRepository
    {
        IEnumerable<Volunteer> Volunteer { get; }

        void SaveVolunteer(Volunteer volunteer);
    }
}
