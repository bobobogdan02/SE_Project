using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.AppLogic.Services;
using GymProject.ViewModel.BookClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class BookController : Controller
    {
        private readonly BookClassServices bookServices;
        private readonly ClassServices classServices;
        private readonly UserManager<IdentityUser> UserManager;
        public BookController(BookClassServices bookServices,ClassServices classServices,UserManager<IdentityUser> userManager)
        {
            this.bookServices = bookServices;
            this.classServices = classServices;
            this.UserManager = userManager;
        }
        
        public IActionResult Index()
        {
            var classList = classServices.GetAll();
            IList<String> className = new List<String>();
            foreach (var item in classList)
            {
                className.Add(item.ClassName);
            }
            ViewData["classname"] = className;
            return View(new BookClassViewModel());
        }
        [HttpPost]
        public IActionResult Index(BookClassViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var className = model.ClassName;
            var idClass = classServices.GetByName(className);
            var Id = UserManager.GetUserId(User);
            Guid SignInId = Guid.Parse(Id);
            bookServices.Book(SignInId,model.Name,model.Surname,model.PhoneNr, idClass.Id);
            return RedirectToAction("Index");

        }
    }
}