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
        }// end EFVolunteerUpdateUserRepository constructor

        public IEnumerable<VolunteerUpdateUser> VolunteerUpdateUser => context.VolunteerUpdateUser;

        public void SaveVolunteerUpdateUser(VolunteerUpdateUser volunteerUpdateUser)
        {
            
            if (volunteerUpdateUser.VOLUNTEERUPDATEUSERID == 0)
            {
                context.VolunteerUpdateUser.Add(volunteerUpdateUser);
            }// end if(volunteerUpdateUser.VOLUNTEERUPDATEUSERID == 0) check
            else
            {
                VolunteerUpdateUser dbEntry = context.VolunteerUpdateUser
                    .FirstOrDefault(volUpdate => volUpdate.VOLUNTEERUPDATEUSERID == volunteerUpdateUser.VOLUNTEERUPDATEUSERID);
                if (dbEntry != null)
                {
                    dbEntry.VOLUNTEERID = volunteerUpdateUser.VOLUNTEERID;
                    dbEntry.Volunteer = volunteerUpdateUser.Volunteer;
                    dbEntry.UserName = volunteerUpdateUser.UserName;
                    dbEntry.DateUpdated = volunteerUpdateUser.DateUpdated;
                }// end if (dbEntry != null) check
            }// end else
            context.SaveChanges();
            
        }// end SaveVolunteerUpdateUser method
    }// end EFVolunteerUpdateUser class
}// end ElderSourceVolunteerManagementCore.Models namespace
