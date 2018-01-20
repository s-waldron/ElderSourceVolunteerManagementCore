using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class Volunteer2OpportunityController : Controller
    {
        private IVolunteerRepository volunteerRepository;
        private IOpportunityRepository opportunityRepository;
        private IVolunteer2OpportunityRepository volunteer2OpportunityReopsitory;

        public Volunteer2OpportunityController(IVolunteerRepository volRepo,
            IOpportunityRepository oppRepo, IVolunteer2OpportunityRepository v2oRepo)
        {
            volunteerRepository = volRepo;
            opportunityRepository = oppRepo;
            volunteer2OpportunityReopsitory = v2oRepo;
        }

        [HttpPost]
        public IActionResult Index(int VOLUNTEERID)
        {
            Volunteer volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol => vol.VOLUNTEERID == VOLUNTEERID);
            return View(new Volunteer2OpprotunityViewModel {
                Volunteer = volunteer,
                OpportunityList = opportunityRepository.Opportunity
            });
        }
    }
}
