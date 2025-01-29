using CSharpSimpleCRUD.DbContexts;
using CSharpSimpleCRUD.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CSharpSimpleCRUD.Controllers
{
    public class EventListController(DataContext context) : Controller
    {
        private readonly DataContext _context = context;

        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }

        public IActionResult Edit(int id)
        {
            var eventItem = _context.Events.Find(id);

            if (eventItem == null) 
            {
            return NotFound();
            }

            return View(eventItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Event eventItem)
        {
            if (!ModelState.IsValid)
            {
                return View(eventItem);
            }

            _context.Update(eventItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var eventItem = _context.Events.Find(id);

            if (eventItem == null)
            {
                return NotFound();
            }

            _context.Events.Remove(eventItem);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
