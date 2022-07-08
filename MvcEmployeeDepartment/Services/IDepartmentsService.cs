using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment.Services;

public interface IDepartmentsService
{
    Task<List<DepartmentViewModel>> GetAllAsync();
    Task<DepartmentViewModel?> GetByIdAsync(int id);
    Task CreateAsync(DepartmentViewModel department);
}