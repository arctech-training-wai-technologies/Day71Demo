using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment.Services;

public interface IEmployeesService
{
    Task<List<EmployeeViewModel>> GetAllAsync();
    Task<EmployeeViewModel?> GetByIdAsync(int id);
    Task CreateAsync(EmployeeViewModel employee);
    Task<List<DropDownViewModel>> GetDepartmentsForDropDownAsync();
    Task<IEnumerable<EmployeeBonusViewModel>> GetEmployeeBonusPayableAsync(decimal sales, decimal target);
    Task<List<EmployeeViewModel>> GetAllMalesAsync();
    Task<List<EmployeeViewModel>> GetAllFemalesAsync();
}