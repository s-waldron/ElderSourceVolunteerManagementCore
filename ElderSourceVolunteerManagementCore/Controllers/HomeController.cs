using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class HomeController : Controller
    {
        private IOpportunityRepository repository;

        public HomeController(IOpportunityRepository repo)
        {
            repository = repo;
        }

        // GET: /<controller>/
        public IActionResult Index() => View(repository.Opportunity);
    }
}
