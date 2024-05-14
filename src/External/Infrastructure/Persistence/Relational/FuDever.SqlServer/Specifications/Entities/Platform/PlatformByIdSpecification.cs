using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.Platform;

namespace FuDever.SqlServer.Specifications.Entities.Platform;

/// <summary>
///     Represent implementation of platform by platform id specification.
/// </summary>
internal sealed class PlatformByIdSpecification
    : BaseSpecification<Domain.Entities.Platform>,
        IPlatformByIdSpecification
{
    internal PlatformByIdSpecification(Guid platformId)
    {
        WhereExpression = platform => platform.Id == platformId;
    }
}
