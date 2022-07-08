using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcEmployeeDepartment.Data;
using MvcEmployeeDepartment.Data.Models;
using MvcEmployeeDepartment.Data.Repository;
using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment.Services;

public class EmployeesService : IEmployeesService
{
    private readonly ILogger<EmployeesService> _logger;
    private readonly IEmployeeRepository<EmployeeViewModel> _employeeRepository;
    private readonly IDepartmentRepository<DepartmentViewModel> _departmentRepository;

    public EmployeesService(
        ILogger<EmployeesService> logger,
        IEmployeeRepository<EmployeeViewModel> employeeRepository,
        IDepartmentRepository<DepartmentViewModel> departmentRepository)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task<List<EmployeeViewModel>> GetAllAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees;
    }

    public async Task<EmployeeViewModel?> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);

        return employee;
    }

    public async Task CreateAsync(EmployeeViewModel employee)
    {
        await _employeeRepository.CreateAsync(employee);
    }

    public async Task<List<DropDownViewModel>> GetDepartmentsForDropDownAsync()
    {
        return await _departmentRepository.GetForDropDownAsync<DropDownViewModel>();
    }

    public async Task<List<EmployeeViewModel>> GetEmployeesInDepartment(int departmentId)
    {
        var employees = await _employeeRepository.GetEmployeesInDepartmentAsync(departmentId);

        return employees;
    }

    public async Task<IEnumerable<EmployeeBonusViewModel>> GetEmployeeBonusPayable(decimal sales, decimal target)
    {
        var salesDepartmentId = await _departmentRepository.GetIdByNameAsync("Sales");
        var salesEmployees = await _employeeRepository.GetEmployeesInDepartmentAsync(salesDepartmentId);

        var totalBonus = CalculateTotalBonus(sales, target);
        var bonusPerEmployee = totalBonus / salesEmployees.Count;

        var employeesBonus = salesEmployees.Select(se => new EmployeeBonusViewModel
        {
            Id = se.Id,
            Name = se.Name,
            Bonus = bonusPerEmployee
        });

        return employeesBonus;
    }

    private decimal CalculateTotalBonus(decimal sales, decimal target)
    {
        var achievement = sales / target;
        var bonus = 0m;

        if (achievement >= 95)
            bonus = sales * 0.10m;
        else if (achievement >= 85)
            bonus = sales * 0.7m;
        else if (achievement >= 75)
            bonus = sales * 0.5m;

        return bonus;
    }
}