using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
namespace GymProject.DataAccess.BaseRepository
{
    class ClassRepository :BaseRepository<Classes> , IClassesRepository
    {
        public ClassRepository(GymDbContext dbContext) : base(dbContext)
        {

        }
        public Classes GetClassByHour(DateTime date)
        {
            //return dbContext.Classes.Where(hour => hour.HourClass == date).SingleOrDefault();
            throw new Exception();
        }
    }
}
