using MvcEmployeeDepartment.Data.Repository.@base;

namespace MvcEmployeeDepartment.Data.Repository;

public interface IDepartmentRepository<TViewModel> : IRepository<TViewModel>
{
    Task<List<T>> GetForDropDownAsync<T>();
    Task<int> GetIdByNameAsync(string departmentName);
}