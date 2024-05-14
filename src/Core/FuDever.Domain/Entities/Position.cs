using System;
using System.Collections.Generic;
using FuDever.Domain.Entities.Base;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "Positions" table.
/// </summary>
public class Position : IBaseEntity, ITemporarilyRemovedEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    // Navigation collections.
    public IEnumerable<UserDetail> UserDetails { get; set; }

    public static class Metadata
    {
        public static class Name
        {
            public const int MaxLength = 100;

            public const int MinLength = 2;
        }
    }
}
