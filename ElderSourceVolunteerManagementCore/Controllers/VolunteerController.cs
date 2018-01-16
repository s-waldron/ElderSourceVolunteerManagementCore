using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using Microsoft.AspNetCore.Authorization;
using ElderSourceVolunteerManagementCore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class VolunteerController : Controller
    {
        private IVolunteerRepository volunteerRepository;
        private IVolunteer2OpportunityRepository volunteer2OpportunityRepository;
        private IOpportunityRepository opportunityRepository;

        public VolunteerController(IVolunteerRepository vRepo, IVolunteer2OpportunityRepository v2ORepo,
            IOpportunityRepository oppRepo)
        {
            volunteer2OpportunityRepository = v2ORepo;
            volunteerRepository = vRepo;
            opportunityRepository = oppRepo;
        }

        [Authorize]
        public ViewResult ListVolunteerEdit() => View(volunteerRepository.Volunteer);

        // GET: /<controller>/
        public IActionResult VolunteerForm(Cart cart)
        {
            Volunteer2OpportunityViewModel volunteer2OpportunityViewModel = new Volunteer2OpportunityViewModel
            {
                Volunteer = new Volunteer(),
                OpportunityList = cart.Lines
            };
            cart.Clear();
            return View(volunteer2OpportunityViewModel);
        }

        public IActionResult CreateVolunteer(Volunteer2OpportunityViewModel volunteer2OpportunityViewModel)
        {
            if (ModelState.IsValid)
            {
                volunteerRepository.SaveVolunteer(volunteer2OpportunityViewModel.Volunteer);
                if(volunteer2OpportunityViewModel != null)
                {
                    foreach (var opp in volunteer2OpportunityViewModel.OpportunityList)
                    {
                        
                        Volunteer2Opportunity vol2Opp = new Volunteer2Opportunity
                        {
                            Volunteer = volunteerRepository.Volunteer.FirstOrDefault(
                                vol => vol.FirstName == volunteer2OpportunityViewModel.Volunteer.FirstName && 
                                vol.LastName == volunteer2OpportunityViewModel.Volunteer.LastName
                                && vol.Email == volunteer2OpportunityViewModel.Volunteer.Email),
                            Opportunity = opportunityRepository.Opportunity.FirstOrDefault(
                                opp1 => opp1.OpportunityName == volunteer2OpportunityViewModel.Opportunity.OpportunityName),
                            VOLUNTEERID = volunteerRepository.Volunteer.FirstOrDefault(
                                vol => vol.FirstName == volunteer2OpportunityViewModel.Volunteer.FirstName &&
                                vol.LastName == volunteer2OpportunityViewModel.Volunteer.LastName
                                && vol.Email == volunteer2OpportunityViewModel.Volunteer.Email).VOLUNTEERID,
                            OPPORTUNITYID = opportunityRepository.Opportunity.FirstOrDefault(
                                opp2 => opp2.OpportunityName == volunteer2OpportunityViewModel.Opportunity.OpportunityName).OPPORTUNITYID,
                            HoursWorked = 0
                        };
                        volunteer2OpportunityRepository.SaveVolunteer2Opportunity(vol2Opp);
                    }
                }
                return RedirectToAction("ListVolunteerEdit", "Volunteer");
            }// end if(ModelState.IsValid) check
            else
            {
                //something went wrong
                return View(volunteer2OpportunityViewModel.Volunteer);
            }// end else
        }// end CreateVolunteer method

        [Authorize]
        public ViewResult Create() => View("EmployeeForm", new Volunteer());

        public ViewResult Edit(int VolunteerID) => View("EmployeeForm",volunteerRepository.Volunteer.FirstOrDefault
            (vol => vol.VOLUNTEERID == VolunteerID));

        [Authorize]
        [HttpPost]
        public IActionResult EmployeeForm(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                volunteerRepository.SaveVolunteer(volunteer);
                return RedirectToAction("ListVolunteerEdit", "Volunteer");
            }// end if(ModelState.IsValid) check
            else
            {
                //something went wrong
                return View(volunteer);
            }// end else
        }// end EmployeeForm method
    }// end VolunteerController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
