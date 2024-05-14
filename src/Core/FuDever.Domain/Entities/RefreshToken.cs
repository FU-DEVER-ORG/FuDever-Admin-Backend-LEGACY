using System;
using FuDever.Domain.Entities.Base;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "RefreshTokens" table.
/// </summary>
public class RefreshToken : IBaseEntity
{
    public Guid AccessTokenId { get; set; }

    public string RefreshTokenValue { get; set; }

    public DateTime ExpiredDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public static class Metadata
    {
        public static class RefreshTokenValue
        {
            public const int MaxLength = 100;

            public const int MinLength = 2;
        }
    }
}
