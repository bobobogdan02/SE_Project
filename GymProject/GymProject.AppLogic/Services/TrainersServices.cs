using System;
using System.Collections.Generic;
using System.Text;
using GymProject.AppLogic.Models;
using GymProject.AppLogic.Repository;


namespace GymProject.AppLogic.Services
{
    public class TrainersServices
    {
        private ITrainersRepository trainersRepository;
       
        public TrainersServices(ITrainersRepository trainersRepository)
        {
            this.trainersRepository = trainersRepository;
         
        }
        public Trainers GetTrainersByName(string name)
        {
            var nameTrainer = trainersRepository.GetTrainersByName(name);
            if (nameTrainer == null)
            {
                throw new EntryPointNotFoundException(name);
            }
            return nameTrainer;
        }
        public Trainers GetTrainersByClass(Classes classId)
        {
            var nameTrainer = trainersRepository.GetTrainersByClass(classId);
            return nameTrainer;
        }
        public IEnumerable<Trainers> GetAllTrainers()
        {
            return trainersRepository.GetAll();
        }
        public Trainers GetTrainersById(Guid Id)
        {
            return trainersRepository.GetTrainersById(Id);
        }
        public void AddTrainer(Guid classId,string name,string surname)
        {
            
            trainersRepository.Add(new Trainers() {Id=Guid.NewGuid(),Name = name, Surname = surname,ClassId=classId });
        }
        
        
        public Trainers Update (Guid id,string name, string surname, Guid classId)
        {
            var trainer = trainersRepository.GetTrainersById(id);
            
            if(trainer==null)
            {
                throw new Exception("Trainer Not Found");
            }
            trainer.Update(name, surname, classId);
           return  trainersRepository.Update(trainer);
            
            
        }
        public void Delete(string idToDelete)
        {
            Guid id = Guid.Empty;
            Guid.TryParse(idToDelete, out id);
            var trainers = trainersRepository.GetTrainersById(id);
            trainersRepository?.Delete(trainers);
            
        }
        public string GetClassName(Classes classId)
        {
            return trainersRepository.GetClassName(classId);
        }
    }
   
}
