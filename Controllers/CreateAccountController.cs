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

            ViewData["ResultMessage"] = resultMessage;

            //If all entries are filled in correctly, proceed.
            if(user.ValidateUser())
            {
                UserManager userManager = new UserManager();

                //Check if user already exists by checking their email.
                if(userManager.CheckUser(user.Email) == false)
                {
                    int userID = userManager.AddUser(user);
                    ViewData["UserID"] = userID.ToString();
                }
                else
                {
                    ViewData["ResultMessage"] = "User account already exists."; 
                }
            }
            
            return View("~/Views/Shared/CreateAccount.cshtml");
        }
    }
}
