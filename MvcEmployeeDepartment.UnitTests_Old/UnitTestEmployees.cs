using Microsoft.Extensions.Logging;
using MvcEmployeeDepartment.Data.Repository;
using MvcEmployeeDepartment.Services;
using MvcEmployeeDepartment.ViewModels;
using NSubstitute;

namespace MvcEmployeeDepartment.UnitTests;

public class UnitTestEmployees
{
    private readonly IEmployeesService _sut;

    private readonly ILogger<EmployeesService> _logger =
        Substitute.For<ILogger<EmployeesService>>();

    private readonly IEmployeeRepository<EmployeeViewModel> _employeeRepository =
        Substitute.For<IEmployeeRepository<EmployeeViewModel>>();

    private readonly IDepartmentRepository<DepartmentViewModel> _departmentRepository =
        Substitute.For<IDepartmentRepository<DepartmentViewModel>>();

    public UnitTestEmployees()
    {
        _sut = new EmployeesService(_logger, _employeeRepository, _departmentRepository);
    }

    [Fact]
    public async Task UnitTestEmployeesRecordsReturningCorrectly()
    {
        // Arrange
        var expectedEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M'},
            new() {Id = 2, Name = "Test User 2", Gender = 'F'},
            new() {Id = 3, Name = "Test User 3", Gender = 'F'}
        };
        _employeeRepository.GetAllAsync().Returns(expectedEmployees);

        // Act
        var actualEmployees = await _sut.GetAllAsync();

        // Assert
        Assert.Equal(expectedEmployees.Count, actualEmployees.Count);

        for (int i = 0; i < expectedEmployees.Count; i++)
        {
            Assert.Equal(expectedEmployees[i].Id, actualEmployees[i].Id);
            Assert.Equal(expectedEmployees[i].Name, actualEmployees[i].Name);
        }
    }

    public async Task UnitTestEmployeeBonus()
    {
        // Arrange
        var sales = 5000000M;
        var target = 6000000M;
        var expectedTotalBonus = 250000;

        var expectedEmployees = new List<EmployeeViewModel>
        {
            new() {Id = 1, Name = "Test User 1", Gender = 'M'},
            new() {Id = 2, Name = "Test User 2", Gender = 'F'}
        };

        _employeeRepository.GetEmployeesInDepartmentAsync(1).Returns(expectedEmployees);

        // Act
        var actualData = await _sut.GetEmployeeBonusPayableAsync(5000000, 6000000);


        // Assert
    }
}