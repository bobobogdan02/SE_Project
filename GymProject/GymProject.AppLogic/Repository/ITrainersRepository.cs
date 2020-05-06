using System;
using System.Collections.Generic;
using System.Text;
using GymProject.AppLogic.Models;
namespace GymProject.AppLogic.Repository
{
    public interface ITrainersRepository :IRepository<Trainers>
    {
        Trainers GetTrainersByName(string name);
        Trainers GetTrainersByClass(Classes classId);
        Trainers GetTrainersById(Guid Id);
        string GetClassName(Classes classId);
    }
}
