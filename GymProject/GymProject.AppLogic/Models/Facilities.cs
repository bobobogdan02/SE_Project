using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.AppLogic.Models
{
    public class Facilities
    {
        public int Id { get; set; }
        public int IdPrices { get; set; }
        public Boolean Sauna { get; set; }
        public Boolean Classes { get; set; }
        public Boolean FitnessGym { get; set; }
        public PriceAbonament prices { get; set; }
    }
}
