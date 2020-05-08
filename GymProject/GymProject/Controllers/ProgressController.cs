using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.AppLogic.Services;
using GymProject.ViewModel.Progress;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class ProgressController : Controller
    {
        private readonly ProgressServices progressServices;
        
        private readonly UserManager<IdentityUser> UserManager;
        public ProgressController(ProgressServices progressServices, UserManager<IdentityUser> UserManager)
        {
            this.progressServices = progressServices;

            this.UserManager = UserManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsertData()
        {
            return View(new ProgressViewModel { });
        }
        [HttpPost]
        public IActionResult InsertData(ProgressViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Id = UserManager.GetUserId(User);
            Guid SignInId = Guid.Parse(Id);
            progressServices.AddStats(SignInId, model.Kg, model.ArmLeft, model.ArmRight, model.Height, model.Shoulders, model.Chest, model.Belly, model.Fesier, model.Legs, model.Gender);
            return RedirectToAction("Index");
        }
    }
}