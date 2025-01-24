using CSharpSimpleCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpSimpleCRUD.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ViewBag.SuccessMessage = "Your form has been submitted successfully.";
            ModelState.Clear();
            return View();
        }
    }
}
