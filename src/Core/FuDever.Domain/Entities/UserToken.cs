using System;
using FuDever.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "UserTokens" table.
/// </summary>
public class UserToken : IdentityUserToken<Guid>, IBaseEntity
{
    // Navigation properties.
    public User User { get; set; }
}
