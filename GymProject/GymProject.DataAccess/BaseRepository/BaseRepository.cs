﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymProject.AppLogic.Repository;
namespace GymProject.DataAccess.BaseRepository
{
    public class BaseRepository<T> :IRepository<T> where T:class ,new()
    {
        protected readonly GymDbContext dbContext;
        public BaseRepository(GymDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public T Add(T itemToAdd)
        {
            var entity = dbContext.Add<T>(itemToAdd);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(T itemToDelete)
        {
            dbContext.Remove<T>(itemToDelete);
            dbContext.SaveChanges();
            return true;
        }
        
        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public T Update(T itemToUpdate)
        {
            var entity = dbContext.Update<T>(itemToUpdate);
            dbContext.SaveChanges();
            return entity.Entity;
        }
    }
}
