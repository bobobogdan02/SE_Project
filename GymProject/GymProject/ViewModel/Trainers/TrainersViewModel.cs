using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.AppLogic.Models;

namespace GymProject.ViewModel.Trainers
{
    public class TrainersViewModel
    {
        public string ClassName { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Guid classId { get; set; }

    }
}
