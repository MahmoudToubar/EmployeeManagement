using Employee_Management.Models;
using Employee_Management.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_Management.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            this.employeeRepository = employeeRepository;
        }

        public async Task <IActionResult> Index()
        {
            var employees = await employeeRepository.GetAllAsync();

            return View(employees);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}