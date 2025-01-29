using CSharpSimpleCRUD.DbContexts;
using CSharpSimpleCRUD.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpSimpleCRUD.Controllers
{
    public class EventController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Event model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.Events.Add(model);
            _context.SaveChanges();

            ViewBag.SuccessMessage = "Your event has been successfully submitted!";
            ModelState.Clear();
            return View();
        }
    }
}

