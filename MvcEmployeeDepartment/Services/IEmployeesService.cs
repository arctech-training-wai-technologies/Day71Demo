using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment.Services;

public interface IEmployeesService
{
    Task<List<EmployeeViewModel>> GetAllAsync();
    Task<EmployeeViewModel?> GetByIdAsync(int id);
    Task CreateAsync(EmployeeViewModel employee);
    Task<List<DropDownViewModel>> GetDepartmentsForDropDownAsync();
    Task<IEnumerable<EmployeeBonusViewModel>> GetEmployeeBonusPayable(decimal sales, decimal target);
}