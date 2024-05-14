using System.ComponentModel.DataAnnotations;
using FuDever.WebApi.DTOs.Others;

namespace FuDever.WebApi.DTOs.Department.Incomings;

/// <summary>
///     Incoming DTO for updating existing Department.
/// </summary>
public sealed class UpdateDepartmentDto : IDtoNormalization
{
    [Required]
    public string NewDepartmentName { get; set; }

    public void NormalizeAllProperties()
    {
        NewDepartmentName = NewDepartmentName.Trim();
    }
}
