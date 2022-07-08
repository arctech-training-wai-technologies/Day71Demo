using Microsoft.Extensions.Logging;
using MvcEmployeeDepartment.Data.Repository;
using MvcEmployeeDepartment.Services;
using MvcEmployeeDepartment.ViewModels;
using NSubstitute;

namespace MvcEmployeeDepartment.UnitTests;

public class UnitTestEmployeeService
{
    // System Under Test - EmployeeService
    private readonly IEmployeesService _sut;

    private readonly ILogger<EmployeesService> _logger;
    private readonly IEmployeeRepository<EmployeeViewModel> _employeeRepository;
    private readonly IDepartmentRepository<DepartmentViewModel> _departmentRepository;

    public UnitTestEmployeeService()
    {
        _logger = Substitute.For<ILogger<EmployeesService>>();
        _employeeRepository = Substitute.For<IEmployeeRepository<EmployeeViewModel>>();
        _departmentRepository = Substitute.For<IDepartmentRepository<DepartmentViewModel>>();

        _sut = new EmployeesService(_logger, _employeeRepository, _departmentRepository);
    }

    [Fact]
    public async Task TestGetAllAsync()
    {
        // Arrange
        var expectedEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M'},
            new() {Id = 2, Name = "Test User 2", Gender = 'F'},
            new() {Id = 3, Name = "Test User 3", Gender = 'M'},
            new() {Id = 4, Name = "Test User 3", Gender = 'F'},
            new() {Id = 5, Name = "Test User 4", Gender = 'M'}
        };

        _employeeRepository.GetAllAsync().Returns(expectedEmployees);

        // Act
        var employee = await _sut.GetAllAsync();

        // Assert
        Assert.Equal(expectedEmployees.Count, employee.Count);

        for (int i = 0; i < expectedEmployees.Count; i++)
        {
            Assert.Equal(expectedEmployees[i].Id, employee[i].Id);
            Assert.Equal(expectedEmployees[i].Name, employee[i].Name);
        }
    }

    [Fact]
    public async Task TestGetAllMalesAsync()
    {
        // Arrange
        var expectedEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M'},
            new() {Id = 2, Name = "Test User 2", Gender = 'F'},
            new() {Id = 3, Name = "Test User 3", Gender = 'M'},
            new() {Id = 4, Name = "Test User 3", Gender = 'F'},
            new() {Id = 5, Name = "Test User 4", Gender = 'M'}
        };

        var expectedMaleEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M'},
            new() {Id = 3, Name = "Test User 3", Gender = 'M'},
            new() {Id = 5, Name = "Test User 4", Gender = 'M'}
        };

        _employeeRepository.GetAllAsync().Returns(expectedEmployees);

        // Act
        var employeeMales = await _sut.GetAllMalesAsync();

        // Assert
        Assert.Equal(employeeMales.Count, expectedMaleEmployees.Count);

        for (int i = 0; i < expectedMaleEmployees.Count; i++)
        {
            Assert.Equal(employeeMales[i].Id, expectedMaleEmployees[i].Id);
            Assert.Equal(employeeMales[i].Name, expectedMaleEmployees[i].Name);
        }
    }

    [Fact]
    public async Task TestGetAllFemalesAsync()
    {
        // Arrange
        var expectedEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M'},
            new() {Id = 2, Name = "Test User 2", Gender = 'F'},
            new() {Id = 3, Name = "Test User 3", Gender = 'M'},
            new() {Id = 4, Name = "Test User 3", Gender = 'F'},
            new() {Id = 5, Name = "Test User 4", Gender = 'M'}
        };

        var expectedFemaleEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 2, Name = "Test User 2", Gender = 'F'},
            new() {Id = 4, Name = "Test User 3", Gender = 'F'},
        };

        _employeeRepository.GetAllAsync().Returns(expectedEmployees);

        // Act
        var employeeFemales = await _sut.GetAllFemalesAsync();

        // Assert
        Assert.Equal(employeeFemales.Count, expectedFemaleEmployees.Count);

        for (int i = 0; i < expectedFemaleEmployees.Count; i++)
        {
            Assert.Equal(employeeFemales[i].Id, expectedFemaleEmployees[i].Id);
            Assert.Equal(employeeFemales[i].Name, expectedFemaleEmployees[i].Name);
        }
    }

    [Theory]
    [InlineData(60_00_000, 50_00_000, 50_00_000 * 0.05)]
    [InlineData(5_25_00_000, 5_15_00_000, 5_15_00_000 * 0.10)]
    [InlineData(25_000, 30_000, 30000 * 0.10)]
    public async Task TestGetEmployeeBonusPayableAsync(decimal target, decimal sales, decimal expectedTotalBonus)
    {
        // Arrange
        var expectedEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M', DepartmentRefId = 2},
            new() {Id = 2, Name = "Test User 2", Gender = 'F', DepartmentRefId = 2},
            new() {Id = 3, Name = "Test User 3", Gender = 'M', DepartmentRefId = 2},
            new() {Id = 4, Name = "Test User 4", Gender = 'F', DepartmentRefId = 2}
        };

        decimal expectedPerPersonBonus = expectedTotalBonus / expectedEmployees.Count;

        _employeeRepository.GetEmployeesInDepartmentAsync(2).Returns(expectedEmployees);

        // Act
        var actualEmployeeBonusInfo = await _sut.GetEmployeeBonusPayableAsync(sales, target);

        // Assert
        Assert.Equal(expectedEmployees.Count, actualEmployeeBonusInfo.Count());

        foreach (var employeeBonusViewModel in actualEmployeeBonusInfo)
        {
            Assert.Equal(expectedPerPersonBonus, employeeBonusViewModel.Bonus);
        }
    }
}