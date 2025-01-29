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

        // GET: Participants/Edit?id=123
        public IActionResult Edit(int id)
        {
            ParticipantModel participant = new ParticipantModel().FetchFromDatabase(id);
            return View(participant);
        }

    }
}
