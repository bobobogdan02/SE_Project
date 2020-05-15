using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GymProject.DataAccess.BaseRepository
{
    public class BookRepository:BaseRepository<Booking> ,IBookClassRepository
    {
        public BookRepository(GymDbContext dbContext) : base(dbContext)
        {
        }

        public Booking GetByClassName(string ClassName)
        {
            throw new NotImplementedException();
        }

        public Booking GetById(Guid id)
        {
            return dbContext.Booking.Where(item => item.Id == id).SingleOrDefault();
        }
        
        
    }
}
