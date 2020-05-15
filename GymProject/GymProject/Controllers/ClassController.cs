using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.AppLogic.Services;
using GymProject.ViewModel.Class;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class ClassController : Controller
    {
        private readonly ClassServices classServices;
        private readonly BookClassServices book;
        private readonly TrainersServices trainers;
        public ClassController(ClassServices classServices,BookClassServices book, TrainersServices trainers)
        {
            this.classServices = classServices;
            this.book = book;
            this.trainers = trainers;
        }
        public IActionResult Index()
        {
            try
            {
                var classList = classServices.GetAll();
                return View(classList);
            }
            catch
            {
                return BadRequest("Invalid request Recived");
            }
        }
        [HttpGet]
        public IActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddClass(ClassViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            classServices.AddClass(model.ClassName,model.HourClass);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            try
            {
                var classList = classServices.GetById(id);
                var viewModel = new ClassViewModel
                {
                    Id = id,
                    ClassName = classList.ClassName,
                    HourClass = classList.HourClass
                   
                };
                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpPost]
        public IActionResult Edit(ClassViewModel viewModel)
        {
            try
            {
                classServices.Update(viewModel.Id, viewModel.ClassName, viewModel.HourClass);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public IActionResult Delete(string Id)
        {
            try
            {
                Guid id = Guid.Empty;
                Guid.TryParse(Id, out id);
                var bookList = book.GetAllBooking();
                foreach(var item in bookList)
                {
                    if(item.ClassId==id)
                    {
                        book.Delete((item.Id).ToString());
                    }
                }
                var trainersList = trainers.GetAllTrainers();
                foreach (var item in trainersList)
                {
                    if (item.ClassId == id)
                    {
                        trainers.Delete((item.Id).ToString());
                    }
                }
                classServices.Delete(Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
