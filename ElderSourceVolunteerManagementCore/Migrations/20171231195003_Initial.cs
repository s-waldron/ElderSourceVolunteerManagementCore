using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ElderSourceVolunteerManagementCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    OPPORTUNITYID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OpportunityAdmin = table.Column<bool>(nullable: false),
                    OpportunityCaregiver = table.Column<bool>(nullable: false),
                    OpportunityDate = table.Column<DateTime>(nullable: false),
                    OpportunityDescription = table.Column<string>(nullable: true),
                    OpportunityDiseaseManagement = table.Column<bool>(nullable: false),
                    OpportunityElderSource = table.Column<bool>(nullable: false),
                    OpportunityElderSourceInstitute = table.Column<bool>(nullable: false),
                    OpportunityEvents = table.Column<bool>(nullable: false),
                    OpportunityFallsPrevention = table.Column<bool>(nullable: false),
                    OpportunityGeneral = table.Column<bool>(nullable: false),
                    OpportunityHealthyLiving = table.Column<bool>(nullable: false),
                    OpportunityMentalWellness = table.Column<bool>(nullable: false),
                    OpportunityName = table.Column<string>(nullable: true),
                    OpportunityNutrition = table.Column<bool>(nullable: false),
                    OpportunityOtherInterest = table.Column<string>(nullable: true),
                    OpportunitySocialMedia = table.Column<bool>(nullable: false),
                    OpportunityTrainingFacilitator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.OPPORTUNITYID);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    VOLUNTEERID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActivitiesParticipated = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Admin = table.Column<bool>(nullable: false),
                    AvailableFriday = table.Column<bool>(nullable: false),
                    AvailableFridayAfternoon = table.Column<bool>(nullable: false),
                    AvailableFridayEvening = table.Column<bool>(nullable: false),
                    AvailableFridayMorning = table.Column<bool>(nullable: false),
                    AvailableMonday = table.Column<bool>(nullable: false),
                    AvailableMondayAfternoon = table.Column<bool>(nullable: false),
                    AvailableMondayEvening = table.Column<bool>(nullable: false),
                    AvailableMondayMorning = table.Column<bool>(nullable: false),
                    AvailableSaturday = table.Column<bool>(nullable: false),
                    AvailableSaturdayAfternoon = table.Column<bool>(nullable: false),
                    AvailableSaturdayEvening = table.Column<bool>(nullable: false),
                    AvailableSaturdayMorning = table.Column<bool>(nullable: false),
                    AvailableSunday = table.Column<bool>(nullable: false),
                    AvailableSundayAfternoon = table.Column<bool>(nullable: false),
                    AvailableSundayEvening = table.Column<bool>(nullable: false),
                    AvailableSundayMorning = table.Column<bool>(nullable: false),
                    AvailableThursday = table.Column<bool>(nullable: false),
                    AvailableThursdayAfternoon = table.Column<bool>(nullable: false),
                    AvailableThursdayEvening = table.Column<bool>(nullable: false),
                    AvailableThursdayMorning = table.Column<bool>(nullable: false),
                    AvailableTuesday = table.Column<bool>(nullable: false),
                    AvailableTuesdayAfternoon = table.Column<bool>(nullable: false),
                    AvailableTuesdayEvening = table.Column<bool>(nullable: false),
                    AvailableTuesdayMorning = table.Column<bool>(nullable: false),
                    AvailableWednesday = table.Column<bool>(nullable: false),
                    AvailableWednesdayAfternoon = table.Column<bool>(nullable: false),
                    AvailableWednesdayEvening = table.Column<bool>(nullable: false),
                    AvailableWednesdayMorning = table.Column<bool>(nullable: false),
                    BackgroundCheck = table.Column<string>(nullable: true),
                    Caregiver = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DiseaseManagement = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Events = table.Column<bool>(nullable: false),
                    FallsPrevention = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Flagged = table.Column<bool>(nullable: false),
                    FlaggedInformation = table.Column<string>(nullable: true),
                    General = table.Column<bool>(nullable: false),
                    GeneralNotes = table.Column<string>(nullable: true),
                    HealthyLiving = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MarkVolunteer = table.Column<bool>(nullable: false),
                    MentalWellness = table.Column<bool>(nullable: false),
                    Nutrition = table.Column<bool>(nullable: false),
                    OtherInterest = table.Column<string>(nullable: true),
                    SocialMedia = table.Column<bool>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    TrainingFacilitator = table.Column<bool>(nullable: false),
                    UpdateHours = table.Column<int>(nullable: false),
                    ZipCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.VOLUNTEERID);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer2Opportunities",
                columns: table => new
                {
                    VOLUNTEER2OPPORTUNITYID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HoursWorked = table.Column<int>(nullable: false),
                    OPPORTUNITYID = table.Column<int>(nullable: false),
                    VOLUNTEERID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer2Opportunities", x => x.VOLUNTEER2OPPORTUNITYID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunities");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "Volunteer2Opportunities");
        }
    }
}
