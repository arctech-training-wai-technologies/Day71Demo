using System.ComponentModel.DataAnnotations;

namespace MvcEmployeeDepartment.ViewModels;

public class EmployeeBonusViewModel
{
    [Display(Name = "Employee Id")] public int Id { get; set; }

    [Display(Name = "Full Name")] public string Name { get; set; } = null!;

    public decimal Bonus { get; set; }
}