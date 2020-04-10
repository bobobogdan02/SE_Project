using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.AppLogic.Models
{
    public class Progress
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int Kg { get; set; }
        public int Height { get; set; }
        public int ArmLeft { get; set; }
        public int ArmRight { get; set; }
        public int Shoulders { get; set; }
        public int Chest { get; set; }
        public int Belly { get; set; }
        public int Fesier { get; set; }
        public int Legs { get; set; }
        public string Gender { get; set; }

    }
}
