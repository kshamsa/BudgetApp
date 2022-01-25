using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class CreateAccount : Controller
    {
        // GET: CreateAccount
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreateAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreateAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreateAccount/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreateAccount/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreateAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreateAccount/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
