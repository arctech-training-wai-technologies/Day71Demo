using System.ComponentModel.DataAnnotations;

namespace MvcEmployeeDepartment.Data.Models;

public class ModelBase
{
    public int Id { get; set; }

    [Required] public bool IsActive { get; set; } = true;

    [Required] public DateTime? LastUpdatedOn { get; set; } = DateTime.Now;
}