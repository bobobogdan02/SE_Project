using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.AppLogic.Models
{
    public class PriceAbonament
    {
        public Guid Id { get; set; }
        public int MonthDuration { get; set; }
        public string TypeAbonament { get; set; }
        public float Price { get; set; }
        
    }

}
