using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using System.Collections;

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
        }// end Volunteer2OpportunityController constructor

        [HttpPost]
        public IActionResult Index(int VOLUNTEERID)
        {
            Volunteer volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol => vol.VOLUNTEERID == VOLUNTEERID);
            return View(new Volunteer2OpprotunityViewModel {
                Volunteer = volunteer,
                OpportunityList = opportunityRepository.Opportunity,
                VOLUNTEERID = volunteer.VOLUNTEERID
            });
        }// end Index [HttpPost] method
        
        [HttpPost]
        public ViewResult Volunteer2OpportunityEdit(int VOLUNTEERID, int OPPORTUNITYID)
        {
            ViewBag.Hello = "Inside Volunteer2OpportunityEdit method";
            Volunteer volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol => vol.VOLUNTEERID == VOLUNTEERID);
            Opportunity opportunity = opportunityRepository.Opportunity.FirstOrDefault(opp => opp.OPPORTUNITYID == OPPORTUNITYID);
            
            if (check(VOLUNTEERID, OPPORTUNITYID))
            {
                addToTable(volunteer, opportunity, VOLUNTEERID, OPPORTUNITYID);
            }
            ViewData["Volunteer2Opportuinty"] = volunteer2OpportunityReopsitory.Volunteer2Opportunity;
            //volunteer2OpprotunityViewModel.Volunteer = volunteerRepository.Volunteer.FirstOrDefault(vol2 => vol2.VOLUNTEERID == volunteer2OpprotunityViewModel.VOLUNTEERID);
            return View("Edit", support(VOLUNTEERID, OPPORTUNITYID));
        }// end Volunteer2OpportunityEdit [HttpPost] method

        private Volunteer2OpportunityUpdateHoursViewModel support(int VOLUNTEERID, int OPPORTUNITYID)
        {
            Volunteer2OpportunityUpdateHoursViewModel volunteer2OpportunityUpdateHours
                = new Volunteer2OpportunityUpdateHoursViewModel
                {
                    Volunteer2OpportunityList = volunteer2OpportunityReopsitory.Volunteer2Opportunity
                    .Where(opp => opp.VOLUNTEERID == VOLUNTEERID)
                };
            return volunteer2OpportunityUpdateHours;
        }// end support method

        private Boolean check(int VOLUNTEERID, int OPPORTUNITYID)
        {
            Volunteer2Opportunity volunteer2 = volunteer2OpportunityReopsitory.Volunteer2Opportunity
                .FirstOrDefault(v2o => v2o.VOLUNTEERID == VOLUNTEERID && v2o.OPPORTUNITYID == OPPORTUNITYID);
            return volunteer2 == null;
        }// end check method

        private void addToTable(Volunteer volunteer, Opportunity opportunity, int VOLUNTEERID, int OPPORTUNITYID)
        {
            Volunteer2Opportunity volunteer2Opportunity = new Volunteer2Opportunity
            {
                Volunteer = volunteer,
                Opportunity = opportunity,
                OPPORTUNITYID = opportunityRepository.Opportunity.FirstOrDefault(opp1 => opp1.OPPORTUNITYID == OPPORTUNITYID).OPPORTUNITYID,
                VOLUNTEERID = volunteerRepository.Volunteer.FirstOrDefault(vol1 => vol1.VOLUNTEERID == VOLUNTEERID).VOLUNTEERID
            };
            volunteer2OpportunityReopsitory.SaveVolunteer2Opportunity(volunteer2Opportunity);
        }
    }// end Volunteer2OpportunityController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
