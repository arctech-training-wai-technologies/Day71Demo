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

    public async Task<List<EmployeeViewModel>> GetAllMalesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Where(e => e.Gender == 'M').ToList();
    }

    public async Task<List<EmployeeViewModel>> GetAllFemalesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Where(e => e.Gender == 'F').ToList();
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

    public async Task<IEnumerable<EmployeeBonusViewModel>> GetEmployeeBonusPayableAsync(decimal sales, decimal target)
    {
        var salesDepartmentId = 2;
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

    private static decimal CalculateTotalBonus(decimal sales, decimal target)
    {
        var achievement = sales / target;
        var bonus = 0m;

        if (achievement >= 0.95m)
            bonus = sales * 0.10m;
        else if (achievement >= 0.85m)
            bonus = sales * 0.07m;
        else if (achievement >= 0.75m)
            bonus = sales * 0.05m;

        return bonus;
    }
}