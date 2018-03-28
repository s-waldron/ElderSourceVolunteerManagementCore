using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ElderSourceVolunteerManagementCore.Models
{
    public class Opportunity
    {
        [Key]
        public int OPPORTUNITYID { get; set; }
        [Required]
        public string OpportunityName { get; set; }
        [Required]
        public DateTime OpportunityDate { get; set; }
        [Required]
        public string OpportunityStreet { get; set; }
        [Required]
        public string OpportunityCity { get; set; }
        [Required]
        public string OpportunityCounty { get; set; }
        [Required]
        public string OpportunityState { get; set; }
        [Required]
        public int OpportunityZipCode { get; set; }
        public Boolean OpportunityElderSource { get; set; }
        public Boolean OpportunityElderSourceInstitute { get; set; }
        public Boolean OpportunityNutrition { get; set; }
        public Boolean OpportunityTrainingFacilitator { get; set; }
        public Boolean OpportunityAdmin { get; set; }
        public Boolean OpportunityGeneral { get; set; }
        public Boolean OpportunityHealthyLiving { get; set; }
        public Boolean OpportunityDiseaseManagement { get; set; }
        public Boolean OpportunityFallsPrevention { get; set; }
        public Boolean OpportunityCaregiver { get; set; }
        public Boolean OpportunityMentalWellness { get; set; }
        public Boolean OpportunityEvents { get; set; }
        public Boolean OpportunitySocialMedia { get; set; }
        public string OpportunityOtherInterest { get; set; }
        [Required]
        public string OpportunityDescription { get; set; }
    }// end Opportunity class
}// end ElderSourceVolunteerManagementCore.Models namespace
