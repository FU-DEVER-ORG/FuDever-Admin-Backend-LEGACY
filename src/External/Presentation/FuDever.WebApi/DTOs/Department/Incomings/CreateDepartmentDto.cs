using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Department.Incomings;

/// <summary>
///     Incoming DTO for creating new Department.
/// </summary>
public sealed class CreateDepartmentDto : IDtoNormalization
{
    [Required]
    public string DepartmentName { get; set; }

    public void NormalizeAllProperties()
    {
        DepartmentName = DepartmentName.Trim();
    }
}
