using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcEmployeeDepartment.Data.Models;
using MvcEmployeeDepartment.Data.Repository.@base;

namespace MvcEmployeeDepartment.Data.Repository;

public class EmployeeRepository<TViewModel> : Repository<Employee, TViewModel>, IEmployeeRepository<TViewModel>
    where TViewModel : ViewModelBase
{
    private readonly IMapper _mapper;
    private readonly DbSet<Employee> _dbSet;

    public EmployeeRepository(ApplicationDbContext dbContext, IMapper mapper) :
        base(dbContext, mapper, dbContext.Employees)
    {
        _mapper = mapper;
        _dbSet = dbContext.Employees;
    }

    public async Task<List<TViewModel>> GetEmployeesInDepartmentAsync(int departmentId)
    {
        var employeesQuery = _dbSet.Where(e => e.DepartmentRefId == departmentId);

        var employees = await _mapper
            .ProjectTo<TViewModel>(employeesQuery)
            .ToListAsync();

        return employees;
    }
}