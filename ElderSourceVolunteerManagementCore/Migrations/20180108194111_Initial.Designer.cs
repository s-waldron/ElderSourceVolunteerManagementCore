using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ElderSourceVolunteerManagementCore.Models;

namespace ElderSourceVolunteerManagementCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180108194111_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElderSourceVolunteerManagementCore.Models.Opportunity", b =>
                {
                    b.Property<int>("OPPORTUNITYID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("OpportunityAdmin");

                    b.Property<bool>("OpportunityCaregiver");

                    b.Property<DateTime>("OpportunityDate");

                    b.Property<string>("OpportunityDescription");

                    b.Property<bool>("OpportunityDiseaseManagement");

                    b.Property<bool>("OpportunityElderSource");

                    b.Property<bool>("OpportunityElderSourceInstitute");

                    b.Property<bool>("OpportunityEvents");

                    b.Property<bool>("OpportunityFallsPrevention");

                    b.Property<bool>("OpportunityGeneral");

                    b.Property<bool>("OpportunityHealthyLiving");

                    b.Property<bool>("OpportunityMentalWellness");

                    b.Property<string>("OpportunityName");

                    b.Property<bool>("OpportunityNutrition");

                    b.Property<string>("OpportunityOtherInterest");

                    b.Property<bool>("OpportunitySocialMedia");

                    b.Property<bool>("OpportunityTrainingFacilitator");

                    b.HasKey("OPPORTUNITYID");

                    b.ToTable("Opportunities");
                });

            modelBuilder.Entity("ElderSourceVolunteerManagementCore.Models.Volunteer", b =>
                {
                    b.Property<int>("VOLUNTEERID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActivitiesParticipated");

                    b.Property<string>("Address");

                    b.Property<bool>("Admin");

                    b.Property<bool>("AvailableFriday");

                    b.Property<bool>("AvailableFridayAfternoon");

                    b.Property<bool>("AvailableFridayEvening");

                    b.Property<bool>("AvailableFridayMorning");

                    b.Property<bool>("AvailableMonday");

                    b.Property<bool>("AvailableMondayAfternoon");

                    b.Property<bool>("AvailableMondayEvening");

                    b.Property<bool>("AvailableMondayMorning");

                    b.Property<bool>("AvailableSaturday");

                    b.Property<bool>("AvailableSaturdayAfternoon");

                    b.Property<bool>("AvailableSaturdayEvening");

                    b.Property<bool>("AvailableSaturdayMorning");

                    b.Property<bool>("AvailableSunday");

                    b.Property<bool>("AvailableSundayAfternoon");

                    b.Property<bool>("AvailableSundayEvening");

                    b.Property<bool>("AvailableSundayMorning");

                    b.Property<bool>("AvailableThursday");

                    b.Property<bool>("AvailableThursdayAfternoon");

                    b.Property<bool>("AvailableThursdayEvening");

                    b.Property<bool>("AvailableThursdayMorning");

                    b.Property<bool>("AvailableTuesday");

                    b.Property<bool>("AvailableTuesdayAfternoon");

                    b.Property<bool>("AvailableTuesdayEvening");

                    b.Property<bool>("AvailableTuesdayMorning");

                    b.Property<bool>("AvailableWednesday");

                    b.Property<bool>("AvailableWednesdayAfternoon");

                    b.Property<bool>("AvailableWednesdayEvening");

                    b.Property<bool>("AvailableWednesdayMorning");

                    b.Property<string>("BackgroundCheck");

                    b.Property<bool>("Caregiver");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<bool>("DiseaseManagement");

                    b.Property<string>("Email");

                    b.Property<bool>("Events");

                    b.Property<bool>("FallsPrevention");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Flagged");

                    b.Property<string>("FlaggedInformation");

                    b.Property<bool>("General");

                    b.Property<string>("GeneralNotes");

                    b.Property<bool>("HealthyLiving");

                    b.Property<string>("LastName");

                    b.Property<bool>("MarkVolunteer");

                    b.Property<bool>("MentalWellness");

                    b.Property<bool>("Nutrition");

                    b.Property<string>("OtherInterest");

                    b.Property<bool>("SocialMedia");

                    b.Property<string>("State");

                    b.Property<bool>("TrainingFacilitator");

                    b.Property<int>("UpdateHours");

                    b.Property<int>("ZipCode");

                    b.HasKey("VOLUNTEERID");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("ElderSourceVolunteerManagementCore.Models.Volunteer2Opportunity", b =>
                {
                    b.Property<int>("VOLUNTEER2OPPORTUNITYID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("HoursWorked");

                    b.Property<int>("OPPORTUNITYID");

                    b.Property<int>("VOLUNTEERID");

                    b.HasKey("VOLUNTEER2OPPORTUNITYID");

                    b.ToTable("Volunteer2Opportunities");
                });
        }
    }
}
