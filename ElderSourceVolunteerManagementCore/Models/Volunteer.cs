using System;
using System.ComponentModel.DataAnnotations;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Volunteer
    {
        [Key]
        public int VOLUNTEERID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Boolean AvailableMonday { get; set; }
        public Boolean AvailableMondayMorning { get; set; }
        public Boolean AvailableMondayAfternoon { get; set; }
        public Boolean AvailableMondayEvening { get; set; }
        public Boolean AvailableTuesday { get; set; }
        public Boolean AvailableTuesdayMorning { get; set; }
        public Boolean AvailableTuesdayAfternoon { get; set; }
        public Boolean AvailableTuesdayEvening { get; set; }
        public Boolean AvailableWednesday { get; set; }
        public Boolean AvailableWednesdayMorning { get; set; }
        public Boolean AvailableWednesdayAfternoon { get; set; }
        public Boolean AvailableWednesdayEvening { get; set; }
        public Boolean AvailableThursday { get; set; }
        public Boolean AvailableThursdayMorning { get; set; }
        public Boolean AvailableThursdayAfternoon { get; set; }
        public Boolean AvailableThursdayEvening { get; set; }
        public Boolean AvailableFriday { get; set; }
        public Boolean AvailableFridayMorning { get; set; }
        public Boolean AvailableFridayAfternoon { get; set; }
        public Boolean AvailableFridayEvening { get; set; }
        public Boolean AvailableSaturday { get; set; }
        public Boolean AvailableSaturdayMorning { get; set; }
        public Boolean AvailableSaturdayAfternoon { get; set; }
        public Boolean AvailableSaturdayEvening { get; set; }
        public Boolean AvailableSunday { get; set; }
        public Boolean AvailableSundayMorning { get; set; }
        public Boolean AvailableSundayAfternoon { get; set; }
        public Boolean AvailableSundayEvening { get; set; }
        public Boolean Nutrition { get; set; }
        public Boolean TrainingFacilitator { get; set; }
        public Boolean Admin { get; set; }
        public Boolean General { get; set; }
        public Boolean HealthyLiving { get; set; }
        public Boolean DiseaseManagement { get; set; }
        public Boolean FallsPrevention { get; set; }
        public Boolean Caregiver { get; set; }
        public Boolean MentalWellness { get; set; }
        public Boolean Events { get; set; }
        public Boolean SocialMedia { get; set; }
        public string OtherInterest { get; set; }
        public string BackgroundCheck { get; set; }
        public string ActivitiesParticipated { get; set; }
        public Boolean MarkVolunteer { get; set; }
        public Boolean Flagged { get; set; }
        public string FlaggedInformation { get; set; }
        public string GeneralNotes { get; set; }
        public int UpdateHours { get; set; }
        public Boolean Interviewed { get; set; }
    }// end Volunteer class
}// end ElderSourceVolunteerManagementCore.Models namespace
