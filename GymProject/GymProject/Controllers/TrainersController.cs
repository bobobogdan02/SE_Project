using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using GymProject.AppLogic.Models;
using GymProject.AppLogic.Services;
using GymProject.ViewModel;
using GymProject.ViewModel.Trainers;

namespace GymProject.Controllers
{
    
    public class TrainersController : Controller
    {
        
        private readonly TrainersServices trainersServices;
        private readonly ClassServices classServices;
        public TrainersController(TrainersServices trainersServices,ClassServices classServices)
        {
            this.trainersServices = trainersServices;
            this.classServices = classServices;
        }
       


        public IActionResult Index()
        {
            try
            {
                var trainersList = trainersServices.GetAllTrainers();
                
              
                return View(trainersList);
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received ");
            }

        }
        [HttpGet]
        public IActionResult AddTrainer()
        {
            var classList = classServices.GetAll();
            IList<String> className = new List<String>();
            foreach(var item in classList)
            {
                className.Add(item.ClassName);
            }
            ViewData["name"] = className;

            return View();
        }
        [HttpPost]
        public IActionResult AddTrainer(TrainersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var className = model.ClassName;
            var idClass = classServices.GetByName(className);
            trainersServices.AddTrainer(idClass.Id, model.Name, model.Surname);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
           try
            {
                var trainers = trainersServices.GetTrainersById(id);
                var viewModel = new TrainersViewModel
                {
                    Id = id,
                    Name = trainers.Name,
                    Surname = trainers.Surname,
                    classId = trainers.ClassId
                };
                return View(viewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }
        [HttpPost]
        public IActionResult Edit(TrainersViewModel viewModel)
        {
            try
            {
                trainersServices.Update(viewModel.Id,viewModel.Name, viewModel.Surname, viewModel.classId);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        public IActionResult Delete (string Id)
        {
            try
            {
                trainersServices.Delete(Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    } 
}