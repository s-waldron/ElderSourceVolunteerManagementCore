using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class Volunteer2OpportunityHoursUpdateController : Controller
    {
        ApplicationDbContext context;
        IVolunteer2OpportunityRepository v2oRepo;
        IVolunteer2OpportunityHoursWorkedRepository v2oHWRepo;

        public Volunteer2OpportunityHoursUpdateController (ApplicationDbContext ctx,
            IVolunteer2OpportunityRepository volunteer2OpportunityRepository, 
            IVolunteer2OpportunityHoursWorkedRepository volunteer2OpportunityHoursWorkedRepository)
        {
            context = ctx;
            v2oRepo = volunteer2OpportunityRepository;
            v2oHWRepo = volunteer2OpportunityHoursWorkedRepository;
        }// end Volunteer2OpportunityHoursUpdateController constructor

        public ViewResult Index(Volunteer2Opportunity v2o)
        {
            ViewBag.Number = v2o.VOLUNTEER2OPPORTUNITYID.ToString();
            if (ModelState.IsValid)
            {
                return View(new Volunteer2OpportunityUpdateHoursViewModel
                {
                    Volunteer2Opportunity = context.Volunteer2Opportunities
                    .Include("Volunteer").Include("Opportunity")
                    .FirstOrDefault(v2o1 => v2o1.VOLUNTEER2OPPORTUNITYID == v2o.VOLUNTEER2OPPORTUNITYID)
                });
            }// end if (ModelState.IsValid) check
            else
            {
                return View("Home/Index");
            }// end else
        }// end Index method
        
        [HttpPost]
        public RedirectToActionResult UpdateHours(Volunteer2Opportunity Volunteer2Opportunity, int Hours, DateTime DateWorked)
        {
            Volunteer2Opportunity volunteer2Opportunity = v2oRepo.Volunteer2Opportunity.FirstOrDefault(v2o => v2o.VOLUNTEER2OPPORTUNITYID == Volunteer2Opportunity.VOLUNTEER2OPPORTUNITYID);
            context.Database.BeginTransaction();
            Volunteer2OpportunityHoursWorked volunteer2OpportunityHoursWorked = new Volunteer2OpportunityHoursWorked
            {
                VOLUNTEER2OPPORTUNITYID = volunteer2Opportunity.VOLUNTEER2OPPORTUNITYID,
                Volunteer2Opportunity = volunteer2Opportunity,
                HoursWorked = Hours,
                DateWorked = DateWorked
            };
            v2oHWRepo.SaveVolunteer2OpportunityHoursWorked(volunteer2OpportunityHoursWorked);
            context.Database.CommitTransaction();
            return RedirectToAction("ListVolunteerEdit", "Volunteer");
        }// end UpdateHours HttpPost method
    }// end Volunteer2OpportunityHoursUpdateController class
}// end ElderSourceVolunteerManagementCore.Controller namespace
