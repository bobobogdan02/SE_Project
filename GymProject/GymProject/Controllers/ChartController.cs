using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GymProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            double count = 1000, y = 100;
            Random random = new Random();
            List<DataPoint> dataPoints = new List<DataPoint>();

            for (int i = 0; i < count; i++)
            {
                y += random.Next(-10, 11);
                dataPoints.Add(new DataPoint(i, y));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}