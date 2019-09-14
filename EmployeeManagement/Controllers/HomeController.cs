using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{   
    public class HomeController : Controller
    {
        
        private readonly IEmployeeRepository _employeeRepository;
        // Injecting IEmployeeRepository.
         public HomeController(IEmployeeRepository employeeRepository)
        {
            // "_" is a convention used to identify a certain type of variable.
            // In this case it is used to identify a Interface property.
            _employeeRepository = employeeRepository;
        }


        // After HTTP request program navigates to Starup.cs to determine the chosen route. 
        // This is the Action method that is called currently. 
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        //Displays in Browser
        public ViewResult Details(int? id)
         {
            // Gives access to HomeDetailsViewModel
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id??1),
                PageTitle = "Employee Details"
             };
            
            return View(homeDetailsViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {

            // Checks if any validation rules have been broken and if the data can bind correctly.
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
