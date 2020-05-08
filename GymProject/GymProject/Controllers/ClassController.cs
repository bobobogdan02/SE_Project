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
        public ClassController(ClassServices classServices)
        {
            this.classServices = classServices;
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
