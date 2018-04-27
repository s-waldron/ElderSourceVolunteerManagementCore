using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElderSourceVolunteerManagementCore.Models.ViewModels
{
    public class ReportViewModel
    {
        public DateTime AuditUpdateDate { get; set; }
        public DateTime V2OUpdateDate { get; set; }
        public string Report { get; set; }
        public List<SelectListItem> Reports { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value="aud", Text="Audit"},
            new SelectListItem {Value="v2o", Text="Volunteer2Opportunity Hours Worked"},
        };
    }
}
