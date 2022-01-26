using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class CreateAccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ResultMessage"] = ""; 
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewAccount(UserModel user)
        {
            ViewData["ResultMessage"] = "Success";

            return View("~/Views/Shared/CreateAccount.cshtml"); 
        }
    }
}
