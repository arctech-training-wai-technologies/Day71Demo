namespace MvcEmployeeDepartment.Data.Repository.@base;

public interface IRepository<TViewModel>
{
    Task<List<TViewModel>> GetAllAsync();
    Task<TViewModel?> GetByIdAsync(int id);

    Task CreateAsync(TViewModel employee);
}