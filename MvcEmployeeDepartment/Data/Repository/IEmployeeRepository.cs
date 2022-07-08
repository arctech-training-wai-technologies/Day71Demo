using MvcEmployeeDepartment.Data.Repository.@base;
using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment.Data.Repository;

public interface IEmployeeRepository<TViewModel> : IRepository<TViewModel>
{
    Task<List<TViewModel>> GetEmployeesInDepartmentAsync(int departmentId);
}