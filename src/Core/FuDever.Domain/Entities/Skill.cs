using System;
using FuDever.Domain.Entities.Base;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "Skills" table.
/// </summary>
public class Skill : IBaseEntity, ITemporarilyRemovedEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public DateTime RemovedAt { get; set; }

    public Guid RemovedBy { get; set; }

    public static class Metadata
    {
        public static class Name
        {
            public const int MaxLength = 100;

            public const int MinLength = 1;
        }
    }
}
