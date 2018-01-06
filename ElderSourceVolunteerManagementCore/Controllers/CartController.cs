using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ElderSourceVolunteerManagementCore.Models;
using ElderSourceVolunteerManagementCore.Infrastructure;
using ElderSourceVolunteerManagementCore.Models.ViewModels;

namespace ElderSourceVolunteerManagementCore.Controllers
{
    public class CartController : Controller
    {
        private IOpportunityRepository repository;

        public CartController(IOpportunityRepository repo)
        {
            repository = repo;
        }// end CartController constructor

        public ViewResult Index(string returnUrl)
        {
            return View(new CartViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int opportunityId, string returnUrl)
        {
            Opportunity opportunity = repository.Opportunity
                .FirstOrDefault(o => o.OPPORTUNITYID == opportunityId);
            if (opportunity != null)
            {
                Cart cart = GetCart();
                cart.AddItem(opportunity);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        } // end AddToCart method

        public RedirectToActionResult RemoveFromCart(int opportunityId, string returnUrl)
        {
            Opportunity opportunity = repository.Opportunity
                .FirstOrDefault(o => o.OPPORTUNITYID == opportunityId);

            if (opportunity != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(opportunity);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        } // end RemoveFromCart method

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        } // end GetCart method

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        } // end SaveCart method
    }// end CartController class
}// end ElderSourceVolunteerManagementCore.Controllers namespace
