using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.ViewModel.Administrator
{
    public class NewEmployeeViewModel
    {
        public IEnumerable<IdentityRole> Jobs { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string JobId { get; set; }
    }
    
}
