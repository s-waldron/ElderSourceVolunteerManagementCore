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
        private int volunteerId;
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
            volunteerId = VOLUNTEERID;
            Volunteer volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol => vol.VOLUNTEERID == VOLUNTEERID);
            return View(new Volunteer2OpprotunityViewModel {
                Volunteer = volunteer,
                OpportunityList = opportunityRepository.Opportunity,
                VOLUNTEERID = volunteer.VOLUNTEERID
            });
        }

        [HttpPost]
        public IActionResult Volunteer2OpportunityEdit(Volunteer2OpprotunityViewModel volunteer2OpprotunityViewModel)
        {
            Volunteer volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol => vol.VOLUNTEERID == volunteer2OpprotunityViewModel.VOLUNTEERID);
            Opportunity opportunity = opportunityRepository.Opportunity.FirstOrDefault(opp => opp.OPPORTUNITYID == volunteer2OpprotunityViewModel.OPPORTUNITYID);
            Volunteer2Opportunity volunteer2Opportunity = new Volunteer2Opportunity();
            volunteer2Opportunity.Volunteer = volunteer;
            volunteer2Opportunity.Opportunity = opportunity;
            volunteer2Opportunity.OPPORTUNITYID = opportunityRepository.Opportunity.FirstOrDefault(opp1 => opp1.OPPORTUNITYID == volunteer2OpprotunityViewModel.OPPORTUNITYID).OPPORTUNITYID;
            volunteer2Opportunity.VOLUNTEERID = volunteerRepository.Volunteer.FirstOrDefault(vol1 => vol1.VOLUNTEERID == volunteer2OpprotunityViewModel.VOLUNTEERID).VOLUNTEERID;
            volunteer2Opportunity.HoursWorked = 0;
            volunteer2OpportunityReopsitory.SaveVolunteer2Opportunity(volunteer2Opportunity);
            volunteer2OpprotunityViewModel.Volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol2 => vol2.VOLUNTEERID == volunteer2OpprotunityViewModel.VOLUNTEERID);
            return View("Edit", volunteer2OpprotunityViewModel);
        }
    }
}
