using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class CorporateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}