using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MvcEmployeeDepartment.Data.Models;

public class Department : ModelBase
{
    [Unicode(false)] [StringLength(50)] public string Name { get; set; } = null!;

    [Unicode(false)] [StringLength(500)] public string? Description { get; set; }
}