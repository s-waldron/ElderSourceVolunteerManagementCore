using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFVolunteerUpdateUserRepository : IVolunteerUpdateUserRespository
    {
        private ApplicationDbContext context;

        public EFVolunteerUpdateUserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }// end EFVolunteerRepository constructor

        public IEnumerable<VolunteerUpdateUser> VolunteerUpdateUser => context.VolunteerUpdateUser;

        public void SaveVolunteerUpdateUser(VolunteerUpdateUser volunteerUpdateUser)
        {
            if (volunteerUpdateUser.VOLUNTEERUPDATEUSERID == 0)
            {
                context.VolunteerUpdateUser.Add(volunteerUpdateUser);
            }// end if(volunteer.VOLUNTEERID == 0) check
            else
            {
                VolunteerUpdateUser dbEntry = context.VolunteerUpdateUser
                    .FirstOrDefault(volUpdate => volUpdate.VOLUNTEERUPDATEUSERID == volunteerUpdateUser.VOLUNTEERUPDATEUSERID);
                if (dbEntry != null)
                {
                    dbEntry.VOLUNTEERID = volunteerUpdateUser.VOLUNTEERID;
                    dbEntry.Email = volunteerUpdateUser.Email;
                    dbEntry.AppUsers = volunteerUpdateUser.AppUsers;
                    dbEntry.DateUpdated = System.DateTime.Now;
                }
            }
        }
    }
}
