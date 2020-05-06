using System;
using System.Collections.Generic;
using System.Text;
using GymProject.AppLogic.Models;
namespace GymProject.AppLogic.Repository
{
   public  interface IClassesRepository: IRepository<Classes>
    {
        Classes GetClassByHour(DateTime date);
    }
}
