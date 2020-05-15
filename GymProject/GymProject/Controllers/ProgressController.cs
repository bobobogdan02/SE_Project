using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.AppLogic.Models;
using GymProject.AppLogic.Services;
using GymProject.ViewModel.Progress;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

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
            var progressList = progressServices.GetAllData();
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            List<DataPoint> dataPoints3 = new List<DataPoint>();
            List<DataPoint> dataPoints4= new List<DataPoint>();
            List<DataPoint> dataPoints5 = new List<DataPoint>();
            List<DataPoint> dataPoints6 = new List<DataPoint>();
            List<DataPoint> dataPoints7 = new List<DataPoint>();
            List<DataPoint> dataPoints8 = new List<DataPoint>();
            var Id = UserManager.GetUserId(User);
            Guid SignInId = Guid.Parse(Id);
            foreach (var item in progressList)
            {
                if(item.UserId==SignInId)
                {
                    dataPoints.Add(new DataPoint(item.Month, item.Kg));
                    dataPoints2.Add(new DataPoint(item.Month, item.ArmLeft));
                    dataPoints3.Add(new DataPoint(item.Month, item.ArmRight));
                    dataPoints4.Add(new DataPoint(item.Month, item.Chest));
                    dataPoints5.Add(new DataPoint(item.Month, item.Belly));
                    dataPoints6.Add(new DataPoint(item.Month, item.Fesier));
                    dataPoints7.Add(new DataPoint(item.Month, item.Shoulders));
                    dataPoints8.Add(new DataPoint(item.Month, item.Legs));
                    

                }
            }          
            ViewBag.DataPoints1 = JsonConvert.SerializeObject(dataPoints);
            ViewBag.DataPoints2 = JsonConvert.SerializeObject(dataPoints2);
            ViewBag.DataPoints3 = JsonConvert.SerializeObject(dataPoints3);
            ViewBag.DataPoints4 = JsonConvert.SerializeObject(dataPoints4);
            ViewBag.DataPoints5 = JsonConvert.SerializeObject(dataPoints5);
            ViewBag.DataPoints6 = JsonConvert.SerializeObject(dataPoints6);
            ViewBag.DataPoints7 = JsonConvert.SerializeObject(dataPoints7);
            ViewBag.DataPoints8 = JsonConvert.SerializeObject(dataPoints8);
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
            progressServices.AddStats(SignInId, model.Month, model.Kg, model.ArmLeft, model.ArmRight, model.Shoulders, model.Chest, model.Belly, model.Fesier, model.Legs, model.Gender);
            return RedirectToAction("Index");
        }
    }
}