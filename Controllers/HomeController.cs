using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BudgetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HomePage(UserModel _User)
        {
            UserManager oUserManager = new UserManager();

            ViewData["UserID"] = oUserManager.LoginUser(_User).Id;
            return View();
        }

        [HttpPost]
        public IActionResult CreateAccount()
        {
            return View(); 
        }

        public IActionResult Budget()
        {
            return View(); 
        }

        public IActionResult Logout()
        {
            ViewData.Clear();
            return View("~/Views/Home/Index.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}