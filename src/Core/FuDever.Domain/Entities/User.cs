using System;
using System.Collections.Generic;
using FuDever.Domain.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace FuDever.Domain.Entities;

/// <summary>
///     Represent the "Users" table.
/// </summary>
public class User : IdentityUser<Guid>, IBaseEntity
{
    public UserDetail UserDetail { get; set; }

    public IEnumerable<UserRole> UserRoles { get; set; }

    public IEnumerable<UserToken> UserTokens { get; set; }

    public static class Metadata
    {
        public static class UserName
        {
            public const int MaxLength = 256;

            public const int MinLength = 2;
        }

        public static class Password
        {
            public const int MinLength = 4;

            public const int MaxLength = 256;
        }
    }
}
