using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using GymProject.AppLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers.Tests
{
    [TestClass()]
    public class TrainersControllerTests
    {
        private readonly TrainersServices trainersServices;
        private readonly ClassServices classServices;
        [TestMethod()]
        public void Index()
        {
            TrainersController controller = new TrainersController(trainersServices, classServices);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}