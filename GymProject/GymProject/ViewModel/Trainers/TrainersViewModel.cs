using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.AppLogic.Models;
namespace GymProject.ViewModel.Trainers
{
    public class TrainersViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Classes classId { get; set; }
    }
}
