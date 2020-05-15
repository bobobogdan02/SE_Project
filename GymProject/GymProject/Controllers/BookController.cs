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
            try
            {
                var bookingList = bookServices.GetAllBooking();
              
                var model = new List<BookClassViewModel>();

                foreach (var item in bookingList)
                {
                    var currentItem = new BookClassViewModel();
                    var name = classServices.GetById(item.ClassId);
                    currentItem.ClassName = name.ClassName;
                    currentItem.Name = item.Name;
                    currentItem.Surname = item.Surname;
                    currentItem.Id = item.Id;
                    currentItem.PhoneNr = item.PhoneNr;
                    model.Add(currentItem);

                }

                ViewData["bookings"] = model;
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }
        
        public IActionResult Add()
        {
           


            var classList = classServices.GetAll();
            IList<String> className = new List<String>();
            foreach (var item in classList)
            {
                className.Add(item.ClassName);
            }
            ViewData["name"] = className;
            return View();
        }
        [HttpPost]
        public IActionResult Add(BookClassViewModel model)
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
        public IActionResult Delete(string id)
        {
            try
            {
                bookServices.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}