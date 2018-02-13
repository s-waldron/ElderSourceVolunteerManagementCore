using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    interface IVolunteerUpdateUserRespository
    {
        IEnumerable<VolunteerUpdateUser> VolunteerUpdateUser { get; }

        void SaveVolunteerUpdateUser(VolunteerUpdateUser volunteerUpdateUser);
    }// end IVolunteerUpdateUser interface
}// end ElderSourceVolunteerManagementCore.Models namespace
