using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class CreateAccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ResultMessage"] = "";
            ViewData["UserID"] = "";
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewAccount(UserModel user)
        {
            string resultMessage = "";

            if(user.FirstName == null)
            {
                resultMessage += "Please enter a first name.<br/>"; 
            }

            if (user.LastName == null)
            {
                resultMessage += "Please enter a last name.<br/>";
            }

            if (user.Email == null)
            {
                resultMessage += "Please enter an email.<br/>";
            }

            if (user.Password == null)
            {
                resultMessage += "Please enter a password.<br/>"; 
            }

            ViewData["ResultMessage"] = resultMessage;

            UserManager userManager = new UserManager();
            int userID = userManager.AddUser(user);

            ViewData["UserID"] = userID.ToString(); 
            return View("~/Views/Shared/CreateAccount.cshtml"); 
        }
    }
}
