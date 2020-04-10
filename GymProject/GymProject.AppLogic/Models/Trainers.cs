using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.AppLogic.Models
{
    public class Trainers
    {
        public int Id { get; set; }
        public int IdClass { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Classes Classes { get; set; }
    }
}
