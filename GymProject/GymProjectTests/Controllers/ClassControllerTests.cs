using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using GymProject.AppLogic.Services;
using GymProject.AppLogic.Repository;
using Microsoft.AspNetCore.Mvc;
using GymProject.Controllers;


namespace GymProject.Controllers.Tests
{
    [TestClass()]
    public class ClassControllerTests
    {
        [TestMethod()]

        public void Index()
        {
            
            var controller = new ClassController(classServices);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}