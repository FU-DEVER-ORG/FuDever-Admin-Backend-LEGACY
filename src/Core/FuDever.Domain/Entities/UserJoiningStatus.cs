using System;
using System.Collections.Generic;
using FuDever.Domain.Entities.Base;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "UserJoiningStatus" table.
/// </summary>
public class UserJoiningStatus : IBaseEntity
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    // Navigation collections.
    public IEnumerable<UserDetail> UserDetails { get; set; }

    public static class Metadata
    {
        public static class Type
        {
            public const int MaxLength = 100;

            public const int MinLength = 2;
        }
    }
}
