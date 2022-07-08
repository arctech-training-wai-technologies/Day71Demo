using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MvcEmployeeDepartment.Data.Models;

namespace MvcEmployeeDepartment.Data.Repository.@base;

public abstract class Repository<TModel, TViewModel> : IRepository<TViewModel>
    where TViewModel : ViewModelBase
    where TModel : ModelBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly DbSet<TModel> _dbSet;

    public Repository(
        ApplicationDbContext dbContext,
        IMapper mapper,
        DbSet<TModel> dbSet)
    {
        _dbContext = dbContext;
        _dbSet = dbSet;
        _mapper = mapper;
    }

    public async Task<List<TViewModel>> GetAllAsync()
    {
        var employees = await _mapper
            .ProjectTo<TViewModel>(_dbSet)
            .ToListAsync();

        return employees;
    }

    public async Task<TViewModel?> GetByIdAsync(int id)
    {
        var employee = await _mapper
            .ProjectTo<TViewModel>(_dbSet)
            .FirstOrDefaultAsync(m => m.Id == id);

        return employee;
    }

    public async Task CreateAsync(TViewModel employee)
    {
        var employeeDataModel = _mapper.Map<TModel>(employee);

        _dbContext.Add(employeeDataModel);
        await _dbContext.SaveChangesAsync();
    }
}