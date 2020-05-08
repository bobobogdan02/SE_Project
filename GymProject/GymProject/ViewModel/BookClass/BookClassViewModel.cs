using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.ViewModel.BookClass
{
    public class BookClassViewModel
    {
        public string ClassName { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNr { get; set; }
        public Guid ClassId { get; set; }
    }
}
