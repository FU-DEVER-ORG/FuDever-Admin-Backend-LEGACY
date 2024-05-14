using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;

namespace FuDever.Application.Features.Auth.Logout;

/// <summary>
///     Logout request handler.
/// </summary>
internal sealed class LogoutRequestHandler : IRequestHandler<LogoutRequest, LogoutResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LogoutRequestHandler(IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    ///     Entry of new request handler.
    /// </summary>
    /// <param name="request">
    ///     Request model.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     A task containing the response.
    /// </returns>
    public async Task<LogoutResponse> Handle(
        LogoutRequest request,
        CancellationToken cancellationToken
    )
    {
        // Get jti claim and convert it to access token id.
        var accessTokenId = Guid.Parse(
            input: _httpContextAccessor.HttpContext.User.FindFirstValue(
                claimType: JwtRegisteredClaimNames.Jti
            )
        );

        // Remove refresh token by access token id.
        var dbResult = await _unitOfWork.AuthFeature.Logout.Command.RemoveByAccessTokenIdAsync(
            accessTokenId: accessTokenId,
            cancellationToken: cancellationToken
        );

        // Cannot remove refresh token.
        if (!dbResult)
        {
            return new() { StatusCode = LogoutResponseStatusCode.DATABASE_OPERATION_FAIL };
        }

        return new() { StatusCode = LogoutResponseStatusCode.OPERATION_SUCCESS };
    }
}
