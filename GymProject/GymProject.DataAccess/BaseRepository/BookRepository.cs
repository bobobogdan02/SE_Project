using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.DataAccess.BaseRepository
{
    public class BookRepository:BaseRepository<Booking> ,IBookClassRepository
    {
        public BookRepository(GymDbContext dbContext) : base(dbContext)
        {
        }
        
        
    }
}
