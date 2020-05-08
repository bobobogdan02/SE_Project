using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
namespace GymProject.DataAccess.BaseRepository
{
    public class ClassRepository :BaseRepository<Classes> , IClassesRepository
    {
        public ClassRepository(GymDbContext dbContext) : base(dbContext)
        {

        }
        

        public Classes GetClassById(Guid id)
        {
             return dbContext.Classes.Where(classId => classId.Id == id).SingleOrDefault();
        
        }
        public Classes GetClassByName(string name)
        {
            return dbContext.Classes.Where(className => className.ClassName == name).SingleOrDefault();
        }
    }
}
