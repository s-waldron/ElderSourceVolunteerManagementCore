using System.Collections.Generic;
using System.Linq;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class EFVolunteerRepository : IVolunteerRepository
    {
        private ApplicationDbContext context;

        public EFVolunteerRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }// end EFVolunteerRepository constructor

        public IEnumerable<Volunteer> Volunteer => context.Volunteers;

        public void SaveVolunteer(Volunteer volunteer)
        {
            if(volunteer.VOLUNTEERID == 0)
            {
                context.Volunteers.Add(volunteer);
            }// end if(volunteer.VOLUNTEERID == 0) check
            else
            {
                Volunteer dbEntry = context.Volunteers
                    .FirstOrDefault(vol => vol.VOLUNTEERID == volunteer.VOLUNTEERID);
                if(dbEntry != null)
                {
                    dbEntry.FirstName = volunteer.FirstName;
                    dbEntry.LastName = volunteer.LastName;
                    dbEntry.Address = volunteer.Address;
                    dbEntry.City = volunteer.City;
                    dbEntry.State = volunteer.State;
                    dbEntry.ZipCode = volunteer.ZipCode;
                    dbEntry.Email = volunteer.Email;
                    dbEntry.DateOfBirth = volunteer.DateOfBirth;
                    dbEntry.AvailableMonday = volunteer.AvailableMonday;
                    dbEntry.AvailableMondayMorning = volunteer.AvailableMondayMorning;
                    dbEntry.AvailableMondayAfternoon = volunteer.AvailableMondayAfternoon;
                    dbEntry.AvailableMondayEvening = volunteer.AvailableMondayEvening;
                    dbEntry.AvailableTuesday = volunteer.AvailableTuesday;
                    dbEntry.AvailableTuesdayMorning = volunteer.AvailableTuesdayMorning;
                    dbEntry.AvailableTuesdayAfternoon = volunteer.AvailableTuesdayAfternoon;
                    dbEntry.AvailableTuesdayEvening = volunteer.AvailableTuesdayEvening;
                    dbEntry.AvailableWednesday = volunteer.AvailableWednesday;
                    dbEntry.AvailableWednesdayMorning = volunteer.AvailableWednesdayMorning;
                    dbEntry.AvailableWednesdayAfternoon = volunteer.AvailableWednesdayAfternoon;
                    dbEntry.AvailableWednesdayEvening = volunteer.AvailableWednesdayEvening;
                    dbEntry.AvailableThursday = volunteer.AvailableThursday;
                    dbEntry.AvailableThursdayMorning = volunteer.AvailableThursdayMorning;
                    dbEntry.AvailableThursdayAfternoon = volunteer.AvailableThursdayAfternoon;
                    dbEntry.AvailableThursdayEvening = volunteer.AvailableThursdayEvening;
                    dbEntry.AvailableFriday = volunteer.AvailableFriday;
                    dbEntry.AvailableFridayMorning = volunteer.AvailableFridayMorning;
                    dbEntry.AvailableFridayAfternoon = volunteer.AvailableFridayAfternoon;
                    dbEntry.AvailableFridayEvening = volunteer.AvailableFridayEvening;
                    dbEntry.AvailableSaturday = volunteer.AvailableSaturday;
                    dbEntry.AvailableSaturdayMorning = volunteer.AvailableSaturdayMorning;
                    dbEntry.AvailableSaturdayAfternoon = volunteer.AvailableSaturdayAfternoon;
                    dbEntry.AvailableSaturdayEvening = volunteer.AvailableSaturdayEvening;
                    dbEntry.AvailableSunday = volunteer.AvailableSunday;
                    dbEntry.AvailableSundayMorning = volunteer.AvailableSundayMorning;
                    dbEntry.AvailableSundayAfternoon = volunteer.AvailableSundayAfternoon;
                    dbEntry.AvailableSundayEvening = volunteer.AvailableSundayEvening;
                    dbEntry.Nutrition = volunteer.Nutrition;
                    dbEntry.TrainingFacilitator = volunteer.TrainingFacilitator;
                    dbEntry.Admin = volunteer.Admin;
                    dbEntry.General = volunteer.General;
                    dbEntry.HealthyLiving = volunteer.HealthyLiving;
                    dbEntry.DiseaseManagement = volunteer.DiseaseManagement;
                    dbEntry.FallsPrevention = volunteer.FallsPrevention;
                    dbEntry.Caregiver = volunteer.Caregiver;
                    dbEntry.MentalWellness = volunteer.MentalWellness;
                    dbEntry.Events = volunteer.Events;
                    dbEntry.SocialMedia = volunteer.SocialMedia;
                    dbEntry.OtherInterest = volunteer.OtherInterest;
                    dbEntry.BackgroundCheck = volunteer.BackgroundCheck;
                    dbEntry.ActivitiesParticipated = volunteer.ActivitiesParticipated;
                    dbEntry.MarkVolunteer = volunteer.MarkVolunteer;
                    dbEntry.Flagged = volunteer.Flagged;
                    dbEntry.FlaggedInformation = volunteer.FlaggedInformation;
                    dbEntry.GeneralNotes = volunteer.GeneralNotes;
                    dbEntry.UpdateHours = volunteer.UpdateHours;
                    dbEntry.Interviewed = volunteer.Interviewed;
                }// end if(dbEntry != null) check
            }// end else
            context.SaveChanges();
        }// end SaveVolunteer method
    }// end EFVolunteerRepository class
}// end ElderSourceVolunteerManagementCore.Models namespace
