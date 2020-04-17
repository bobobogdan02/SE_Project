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
    [Authorize]
    public class TrainersController : Controller
    {
        
        private readonly TrainersServices trainersServices;
        public TrainersController(TrainersServices trainersServices)
        {
            this.trainersServices = trainersServices;
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
            return View();
        }
        [HttpPost]
        public IActionResult AddTrainer([FromForm]TrainersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            trainersServices.AddTrainer(model.classId,model.Name, model.Surname);
            return RedirectToAction("Index", "TrainersController");
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

    } 
}