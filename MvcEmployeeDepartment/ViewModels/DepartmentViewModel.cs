using System.ComponentModel.DataAnnotations;
using MvcEmployeeDepartment.Data.Repository.@base;

namespace MvcEmployeeDepartment.ViewModels;

public class DepartmentViewModel : ViewModelBase
{
    [Display(Name = "Department")] public string Name { get; set; } = null!;

    public string? Description { get; set; }
}