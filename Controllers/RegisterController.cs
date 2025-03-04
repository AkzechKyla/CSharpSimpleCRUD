﻿using CSharpSimpleCRUD.Models;
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
        public IActionResult Index(ParticipantModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.SaveToDatabase();
            ViewBag.SuccessMessage = "Your form has been submitted successfully.";
            ModelState.Clear();
            return View();
        }
    }
}
