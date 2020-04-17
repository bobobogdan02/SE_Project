using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.AppLogic.Models
{
    public class Trainers

    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Classes ClassId { get; set; }

        public void Update(string name, string surname, Classes classId)
        {
            this.Name = name;
            this.Surname = surname;
            this.ClassId = classId;
        }
    }
   
   
}

