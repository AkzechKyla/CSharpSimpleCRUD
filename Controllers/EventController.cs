using Microsoft.AspNetCore.Mvc;

namespace CSharpSimpleCRUD.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
