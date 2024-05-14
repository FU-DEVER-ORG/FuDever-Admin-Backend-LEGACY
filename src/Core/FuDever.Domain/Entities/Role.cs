using System;
using System.Collections.Generic;
using FuDever.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "Roles" table.
/// </summary>
public class Role : IdentityRole<Guid>, IBaseEntity, ITemporarilyRemovedEntity
{
    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    // Navigation collections.
    public IEnumerable<UserRole> UserRoles { get; set; }

    public static class Metadata
    {
        public static class Name
        {
            public const int MaxLength = 50;

            public const int MinLength = 2;
        }
    }
}
