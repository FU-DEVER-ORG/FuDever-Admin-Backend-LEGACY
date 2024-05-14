using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.UserPlatform;

namespace FuDever.SqlServer.Specifications.Entities.UserPlatform;

/// <summary>
///     Represent implementation of user platform by platform
///     id specification.
/// </summary>
internal sealed class UserPlatformByPlatformIdSpecification
    : BaseSpecification<Domain.Entities.UserPlatform>,
        IUserPlatformByPlatformIdSpecification
{
    internal UserPlatformByPlatformIdSpecification(Guid platformId)
    {
        WhereExpression = userPlatform => userPlatform.PlatformId == platformId;
    }
}
