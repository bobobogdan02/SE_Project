using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.AppLogic.Services
{
   public  class BookClassServices
    {
        private readonly IBookClassRepository bookRepository;
        public BookClassServices(IBookClassRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public void Book(Guid UserId,string name,string surname,string phoneNumber,Guid ClassId)
        {
            bookRepository.Add(new Booking() { Id = Guid.NewGuid(), UserId = UserId, Name = name, Surname = surname, PhoneNr = phoneNumber, ClassId = ClassId });
        }

        public IEnumerable<Booking> GetAllBooking()
        {
            return bookRepository.GetAll();
        }
        public Booking GetById(Guid id)
        {
            return bookRepository.GetById(id);
        }
        public void Delete(string id)
        {
            Guid Id = Guid.Empty;
            Guid.TryParse(id, out Id);
            var book = bookRepository.GetById(Id);
            bookRepository?.Delete(book);
        }
    }
}
