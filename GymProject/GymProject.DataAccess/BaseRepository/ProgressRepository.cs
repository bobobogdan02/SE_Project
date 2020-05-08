using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.DataAccess.BaseRepository
{
    public class ProgressRepository:BaseRepository<Progress>, IProgressRepository
    {
        public ProgressRepository(GymDbContext dbContext) : base(dbContext)
        {

        }
    }
}
