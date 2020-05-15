using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymProject.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        [TestMethod]
      public void Index(){
            // Arrange
            HomeController controller = new HomeController();
         // Act
         ViewResult result = controller.Index() as ViewResult;
         // Assert
         Assert.IsNotNull(result);
      }
    }
}