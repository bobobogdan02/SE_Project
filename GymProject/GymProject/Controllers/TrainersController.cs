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
        class Trainer
        {
            string TrainerName;
            string TrainerSurname;
            string ClassName;
           public  Trainer (string name,string surname,string className)
            {
                this.TrainerName = name;
                this.TrainerSurname = surname;
                this.ClassName = className;
            }
        }


        public IActionResult Index()
        {
            try
            {
                var trainersList = trainersServices.GetAllTrainers();
                List<Trainer> trainers = new List<Trainer>();
                
                foreach (var obj in trainersList)
                {
                    var name = trainersServices.GetClassName(obj.ClassId);
                    var info = new Trainer(obj.Name,obj.Surname,name);
                    trainers.Add(info);
                }
                return View(trainers);
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