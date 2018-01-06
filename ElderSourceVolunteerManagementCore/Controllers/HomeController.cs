using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using System.Linq;
using ElderSourceVolunteerManagementCore.Models.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class HomeController : Controller
    {
        private IOpportunityRepository repository;

        public HomeController(IOpportunityRepository repo)
        {
            repository = repo;
        }// end HomeController constructor

        // GET: /<controller>/
        public ViewResult Index(string Interest)
        {
            switch (Interest)
            {
                case "nt":
                    return View(new OpportunityViewModel {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityNutrition == true)
                    });
                case "tf":
                    return View(new OpportunityViewModel {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityTrainingFacilitator == true)
                    });
                case "am":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityAdmin == true)
                    });
                case "gn":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityGeneral == true)
                    });
                case "hl":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityHealthyLiving == true)
                    });
                case "dm":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityDiseaseManagement == true)
                    });
                case "fp":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityFallsPrevention == true)
                    });
                case "cg":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityCaregiver == true)
                    });
                case "mw":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityMentalWellness == true)
                    });
                case "ev":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityEvents == true)
                    });
                case "sm":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunitySocialMedia == true)
                    });
                case "oi":
                    return View(new OpportunityViewModel
                    {
                        Opportunity = repository.Opportunity
                        .Where(o => Interest == null || o.OpportunityOtherInterest != null && o.OpportunityOtherInterest != "")
                    });
                default:
                    return View(new OpportunityViewModel {
                        Opportunity = repository.Opportunity
                    });
            }// end switch(Interest) statment
        }// end Index method
    }// end HomeController class
}// end ElderSourceVolunteerManagementCore.Controller namespace
