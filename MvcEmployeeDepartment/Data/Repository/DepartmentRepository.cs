using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcEmployeeDepartment.Data.Models;
using MvcEmployeeDepartment.Data.Repository.@base;

namespace MvcEmployeeDepartment.Data.Repository;

public class DepartmentRepository<TViewModel> : Repository<Department, TViewModel>, IDepartmentRepository<TViewModel>
    where TViewModel : ViewModelBase
{
    private readonly IMapper _mapper;
    private readonly DbSet<Department> _dbSet;

    public DepartmentRepository(ApplicationDbContext dbContext, IMapper mapper) :
        base(dbContext, mapper, dbContext.Departments)
    {
        _mapper = mapper;
        _dbSet = dbContext.Departments;
    }

    public async Task<List<T>> GetForDropDownAsync<T>()
    {
        var itemsForDropDown = await _mapper
            .ProjectTo<T>(_dbSet)
            .ToListAsync();

        return itemsForDropDown;
    }

    public async Task<int> GetIdByNameAsync(string departmentName)
    {
        var departmentIdQuery = _dbSet
            .Where(d => d.Name == departmentName)
            .Select(d => d.Id);

        return await departmentIdQuery.FirstOrDefaultAsync();
    }
}