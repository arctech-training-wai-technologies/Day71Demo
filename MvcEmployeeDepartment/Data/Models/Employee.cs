using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MvcEmployeeDepartment.Data.Models;

public class Employee : ModelBase
{
    [Unicode(false)] [StringLength(50)] public string Name { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    [Column(TypeName = "char(1)")] public char? Gender { get; set; }

    public int DepartmentRefId { get; set; }

    [ForeignKey(nameof(DepartmentRefId))] public Department DepartmentRef { get; set; } = null!;

    [Column(TypeName = "decimal(10,2)")] public decimal TakeHomeSalary { get; set; }
}