﻿ using AspNetCoreEntry.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreEntry.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View();
        }
        [HttpGet]
        public IActionResult Apply()
        {
            return View();       
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm]Candidate model)
        {
            if (Repository.Applications.Any(c => c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("", "There is already an application for you.");
            }
            if (ModelState.IsValid)
            {
            Repository.Add(model);
            return View("Feedback",model);
            }
            return View();     
        }

    }
}
