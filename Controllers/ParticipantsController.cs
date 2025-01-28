using CSharpSimpleCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CSharpSimpleCRUD.Controllers
{
    public class ParticipantsController : Controller
    {
        public IActionResult Index(ParticipantModel participantModel)
        {
            List<ParticipantModel> participants = participantModel.FetchFromDatabase();
            return View(participants);
        }
    }
}
