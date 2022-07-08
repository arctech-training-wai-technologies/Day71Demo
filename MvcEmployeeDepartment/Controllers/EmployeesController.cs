using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MvcEmployeeDepartment.ViewModels;
using MvcEmployeeDepartment.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcEmployeeDepartment.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesService _employeesService;


        public EmployeesController(ILogger<EmployeesController> logger, IEmployeesService employeesService)
        {
            _logger = logger;
            _employeesService = employeesService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeesService.GetAllAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            ViewData["DepartmentsList"] = await GetSelectedListDepartmentAsync();
            return View();
        }


        private async Task<SelectList?> GetSelectedListDepartmentAsync()
        {
            return new SelectList(await _employeesService.GetDepartmentsForDropDownAsync(),
                nameof(DropDownViewModel.Id), nameof(DropDownViewModel.Text));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeViewModel employeeViewModel)
        {
            await _employeesService.CreateAsync(employeeViewModel);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EmployeeBonus(decimal sales, decimal target)
        {
            var employees = await _employeesService.GetEmployeeBonusPayableAsync(sales, target);
            return View(employees);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}