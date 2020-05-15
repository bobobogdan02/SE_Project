using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using GymProject.AppLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProjectTests.Services
{
    [TestClass]
    class BookClassServicesTest
    {
        IBookClassRepository bookRepository;

        public BookClassServicesTest(IBookClassRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Book(Guid UserId, string name, string surname, string phoneNumber, Guid ClassId)
        {
            bookRepository.Add(new Booking() { Id = Guid.NewGuid(), UserId = UserId, Name = name, Surname = surname, PhoneNr = phoneNumber, ClassId = ClassId });
        }

        [TestMethod]
        public void GetAllBooking()
        {
            var controller = new BookClassServices(bookRepository);

            Assert.IsNotNull(bookRepository);

        }
        
    }
}
