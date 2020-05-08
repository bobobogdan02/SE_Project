using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.AppLogic.Models
{
    public class Classes
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public DateTime HourClass { get; set; }
        public void Update(string className,DateTime time)
        {
            this.ClassName = className;
            this.HourClass = time;
        }
    }
}

