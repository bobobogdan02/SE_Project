using GymProject.AppLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.AppLogic.Repository
{
    public interface IBookClassRepository:IRepository<Booking>
    {
        Booking GetById(Guid id);
        Booking GetByClassName(string ClassName);
    }
}
