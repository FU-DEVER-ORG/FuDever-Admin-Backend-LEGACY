using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.RefreshToken;

namespace FuDever.SqlServer.Specifications.Entities.RefreshToken;

/// <summary>
///     Represent implementation of expiration of refresh token specification.
/// </summary>
internal sealed class RefreshTokenExpiredSpecification
    : BaseSpecification<Domain.Entities.RefreshToken>,
        IRefreshTokenExpiredSpecification
{
    internal RefreshTokenExpiredSpecification()
    {
        var dateTimeNowInUtc = DateTime.UtcNow;

        WhereExpression = refreshToken => refreshToken.ExpiredDate < dateTimeNowInUtc;
    }
}
