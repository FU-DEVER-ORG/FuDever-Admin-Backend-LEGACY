using System;
using FuDever.Domain.Specifications.Base;
using FuDever.Domain.Specifications.Entities.RefreshToken;

namespace FuDever.SqlServer.Specifications.Entities.RefreshToken;

/// <summary>
///     Represent implementation of refresh token
///     by access token id specification.
/// </summary>
internal sealed class RefreshTokenByAccessTokenIdSpecification
    : BaseSpecification<Domain.Entities.RefreshToken>,
        IRefreshTokenByAccessTokenIdSpecification
{
    internal RefreshTokenByAccessTokenIdSpecification(Guid accessTokenId)
    {
        WhereExpression = refreshToken => refreshToken.AccessTokenId == accessTokenId;
    }
}
