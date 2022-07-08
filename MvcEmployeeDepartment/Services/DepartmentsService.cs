using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MvcEmployeeDepartment.Data;
using MvcEmployeeDepartment.Data.Models;
using MvcEmployeeDepartment.ViewModels;

namespace MvcEmployeeDepartment.Services;

public class DepartmentsService : IDepartmentsService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public DepartmentsService(
        ApplicationDbContext dbContext,
        IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<List<DepartmentViewModel>> GetAllAsync()
    {
        //var departments = await _dbContext.Departments.ToListAsync();

        var departments = await _dbContext.Departments
            .Select(d => _mapper.Map<DepartmentViewModel>(d))
            .ToListAsync();

        return departments;
    }

    public async Task<DepartmentViewModel?> GetByIdAsync(int id)
    {
        //var department = await _dbContext.Departments.FirstOrDefaultAsync(m => m.Id == id);

        var department = await _dbContext.Departments.FirstOrDefaultAsync(m => m.Id == id);

        return _mapper.Map<DepartmentViewModel>(department);
    }

    public async Task CreateAsync(DepartmentViewModel department)
    {
        var departmentDataModel = _mapper.Map<Department>(department);

        _dbContext.Add((object) departmentDataModel);
        await _dbContext.SaveChangesAsync();
    }
}