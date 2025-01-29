using CSharpSimpleCRUD.DbContexts;
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
    }
}
