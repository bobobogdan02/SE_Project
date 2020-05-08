using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
namespace GymProject.DataAccess.BaseRepository
{
    public class TrainersRepository : BaseRepository<Trainers>, ITrainersRepository
    {
        public TrainersRepository(GymDbContext dbContext):base(dbContext)
        {

        }
        public Trainers GetTrainersByName(string name)
        {
            //return dbContext.Trainers.Where(trainer => trainer.Name == name).SingleOrDefault(); 
            throw new Exception();
        }
        public Trainers GetTrainersByClass(Classes classId)
        {
             //return dbContext.Trainers.Where(trainer => trainer.Classes.Equals(classId)).SingleOrDefault();
            throw new Exception();
        }
        public Trainers GetTrainersById(Guid Id)
        {
             return dbContext.Trainers.Where(trainer => trainer.Id == Id).SingleOrDefault();
           

        }
        public string GetClassName(Classes classId)
        {
            //var className= dbContext.Classes.Where(class => class.Id.Equals(classId)).SingleOrDefault();
            // return className.Name;
            throw new Exception();
        }
    }
}
