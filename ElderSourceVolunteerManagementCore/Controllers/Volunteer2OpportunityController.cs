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
        private IVolunteer2OpportunityRepository volunteer2OpportunityRepository;

        public Volunteer2OpportunityController(IVolunteerRepository volRepo,
            IOpportunityRepository oppRepo, IVolunteer2OpportunityRepository v2oRepo)
        {
            volunteerRepository = volRepo;
            opportunityRepository = oppRepo;
            volunteer2OpportunityRepository = v2oRepo;
        }


        // GET: /<controller>/
        public ViewResult Index(string id)
        {
            int idNumber = int.Parse(id);
            Volunteer volent = volunteerRepository.Volunteer.FirstOrDefault(vol => vol.VOLUNTEERID == idNumber);
            return View(new Volunteer2OpportunityViewModel {
            Volunteer = volent,
            Opportunities = opportunityRepository.Opportunity});
        }
    }
}
