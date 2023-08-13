using Employee_Management.Data;
using Employee_Management.Models;
using Employee_Management.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public AdminController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(Employee addEmp)
        {
            if(ModelState.IsValid == false)
            {
                return View();
            }
            var employees = new Employee
            {
                EmployeeId = addEmp.EmployeeId,
                Name = addEmp.Name,
                ID = addEmp.ID,
                NationalId = addEmp.NationalId,
                DateOfBirth = addEmp.DateOfBirth,
                Age = addEmp.Age,
                Account = addEmp.Account,
                LineOfBusiness = addEmp.LineOfBusiness,
                Language = addEmp.Language,
                LanguageLevel = addEmp.LanguageLevel
            };

            await employeeRepository.AddAsync(employees);

            return RedirectToAction("List");
        }



        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var employees = await employeeRepository.GetAllAsync();

            return View(employees);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
           
            var employees = await employeeRepository.GetAsync(id);

            if (employees != null)
            {
                var editEmp = new Employee
                {
                    EmployeeId = employees.EmployeeId,
                    Name = employees.Name,
                    ID = employees.ID,
                    NationalId = employees.NationalId,
                    DateOfBirth = employees.DateOfBirth,
                    Age = employees.Age,
                    Account = employees.Account,
                    LineOfBusiness = employees.LineOfBusiness,
                    Language = employees.Language,
                    LanguageLevel = employees.LanguageLevel
                };

                return View(editEmp);

            }

            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Employee editEmp)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Edit");
            }
            var employees = new Employee
            {
                EmployeeId = editEmp.EmployeeId,
                Name = editEmp.Name,
                ID = editEmp.ID,
                NationalId = editEmp.NationalId,
                DateOfBirth = editEmp.DateOfBirth,
                Age = editEmp.Age,
                Account = editEmp.Account,
                LineOfBusiness = editEmp.LineOfBusiness,
                Language = editEmp.Language,
                LanguageLevel = editEmp.LanguageLevel
            };

            var updatedEmp = await employeeRepository.UpdateAsync(employees);

            if (updatedEmp != null)
            {
                return RedirectToAction("List");
            }

            else
            {
                return RedirectToAction("Edit");
            }

            
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Employee editEmp)
        {
            var deletedEmp = await employeeRepository.DeleteAsync(editEmp.EmployeeId);

                if (deletedEmp != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editEmp.EmployeeId });
            
        }


    } 
    
}
