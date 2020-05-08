using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymProject.AppLogic.Services
{
    public class ClassServices
    {
        private readonly IClassesRepository classRepository;
        public ClassServices(IClassesRepository classesRepository)
        {
            this.classRepository = classesRepository;
        }
        public IEnumerable<Classes> GetAll()
        {
             return classRepository.GetAll();
        }
        public Classes GetById(Guid id)
        {
            return classRepository.GetClassById(id);
        }
        public void AddClass(string name,DateTime time)
        {
            classRepository.Add(new Classes() { Id = Guid.NewGuid(), ClassName = name, HourClass = time });
        }
        public Classes Update(Guid id, string name, DateTime time)
        {
            var classes = classRepository.GetClassById(id);

            if (classes == null)
            {
                throw new Exception("Trainer Not Found");
            }
            classes.Update(name,time);
            return classRepository.Update(classes);


        }
        public void Delete(string idToDelete)
        {
            Guid id = Guid.Empty;
            Guid.TryParse(idToDelete, out id);
            var trainers = classRepository.GetClassById(id);
            classRepository?.Delete(trainers);

        }
        public Classes GetByName(string name)
        {
            return classRepository.GetClassByName(name);
        }
        
    }
}
