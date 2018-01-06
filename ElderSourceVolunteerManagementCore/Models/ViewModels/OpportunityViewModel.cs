using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ElderSourceVolunteerManagementCore.Infrastructure;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class OpportunityViewModel
    {

        public IEnumerable<Opportunity> Opportunity { get; set; }

        public string Interest { get; set; }

        public string ReturnUrl { get; set; }

        public List<SelectListItem> Interests { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="nt", Text="Nutrition"},
            new SelectListItem {Value="tf", Text="Training Facilitator"},
            new SelectListItem {Value="am", Text="Admin"},
            new SelectListItem {Value="gn", Text="General"},
            new SelectListItem {Value="hl", Text="Healthy Living"},
            new SelectListItem {Value="dm", Text="Disease Management"},
            new SelectListItem {Value="fp", Text="Falls Prevention"},
            new SelectListItem {Value="cg", Text="Caregiver"},
            new SelectListItem {Value="mw", Text="Mental Wellness"},
            new SelectListItem {Value="ev", Text="Events"},
            new SelectListItem {Value="sm", Text="Social Media"},
            new SelectListItem {Value="oi", Text="Other Interest"},
        };
    }// end IntrestViewModel class
}// end ElderSourceVolunteerManagementCore.Models.ViewModels namespace
