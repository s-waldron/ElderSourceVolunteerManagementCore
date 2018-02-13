using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class OpportunityController : Controller
    {
        private IOpportunityRepository repository;

        public OpportunityController(IOpportunityRepository repo)
        {
            repository = repo;
        }// end OpportunityController constructor
        
        [Authorize (Roles = "Employee,Manager,Admin")]
        public ViewResult ListOpportunityEdit() => View(repository.Opportunity);
        
        [Authorize(Roles = "Employee,Manager,Admin")]
        // GET: /<controller>/
        public ViewResult Edit(int OpportunityID) => View("OpportunityForm",repository.Opportunity.FirstOrDefault(
            opp => opp.OPPORTUNITYID == OpportunityID));

        [Authorize(Roles = "Employee,Manager,Admin")]
        public ViewResult Create() => View("OpportunityForm", new Opportunity());

        [Authorize (Roles = "Employee,Manager,Admin")]
        [HttpPost]
        public IActionResult OpportunityForm(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                repository.SaveOpportunity(opportunity);
                return RedirectToActionPermanent("ListOpportunityEdit", "Opportunity");
            }// end if(ModelState.IsValid) check
            else
            {
                //something went wrong
                return View(opportunity);
            }// end else
        }// end OpportunityForm method
    }// end OpportunityController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
