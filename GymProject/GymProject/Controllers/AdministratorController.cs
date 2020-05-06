using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymProject.ViewModel.Administrator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymProject.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var employeeList = new List<IdentityUser>();
            foreach(var employee in userManager.Users)
            {
                var role = await userManager.GetRolesAsync(employee);
                if (role.Any())
                {
                    employeeList.Add(employee);
                }
            }
            
            return View(new AdministratorViewModel { Employees = employeeList});
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new NewRoleViewModel { });
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewRoleViewModel viewModel)
        {
            var identityRole = new IdentityRole(viewModel.Name);
            await roleManager.CreateAsync(identityRole);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new NewEmployeeViewModel{ Jobs = roleManager.Roles});
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(NewEmployeeViewModel viewModel)
        {
            var user = new IdentityUser { UserName = viewModel.Email, Email = viewModel.Email };
            var result = await userManager.CreateAsync(user, viewModel.Password);
            if(result.Succeeded)
            {
                var identityRole = await roleManager.FindByIdAsync(viewModel.JobId);
                await userManager.AddToRoleAsync(user, identityRole.Name.ToString());
            }
            return RedirectToAction("Index");
        }
    }
}