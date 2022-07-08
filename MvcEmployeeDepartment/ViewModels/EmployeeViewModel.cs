using System.ComponentModel.DataAnnotations;
using MvcEmployeeDepartment.Data.Repository.@base;

namespace MvcEmployeeDepartment.ViewModels;

public class EmployeeViewModel : ViewModelBase
{
    [Display(Name = "Full Name")]
    [StringLength(50)]
    [Required]
    public string Name { get; set; } = null!;

    [Display(Name = "Date Of Birth")] public DateTime? DateOfBirth { get; set; }

    [Required] public char? Gender { get; set; }

    [Display(Name = "Department Id")] public int DepartmentRefId { get; set; }

    [Display(Name = "Department")] public string? DepartmentName { get; set; } = null!;
}