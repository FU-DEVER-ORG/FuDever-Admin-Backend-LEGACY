using System;
using FuDever.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "UserRoles" table.
/// </summary>
public class UserRole : IdentityUserRole<Guid>, IBaseEntity
{
    // Navigation properties.
    public User User { get; set; }

    public Role Role { get; set; }
}
