using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Authorization;
using MediatR;

namespace FuDever.Application.Features.Role.RestoreRoleByRoleId.Middlewares;

/// <summary>
///     Restore role by role id
///     request authorization middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class RestoreRoleByRoleIdAuthorizationMiddleware
    : IPipelineBehavior<RestoreRoleByRoleIdRequest, RestoreRoleByRoleIdResponse>,
        IRestoreRoleByRoleIdMiddleware
{
    private readonly ISender _sender;

    public RestoreRoleByRoleIdAuthorizationMiddleware(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    ///     Entry to middleware handler.
    /// </summary>
    /// <param name="request">
    ///     Current request object.
    /// </param>
    /// <param name="next">
    ///     Navigate to next middleware and get back response.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used for notifying system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     Response of use case.
    /// </returns>
    public async Task<RestoreRoleByRoleIdResponse> Handle(
        RestoreRoleByRoleIdRequest request,
        RequestHandlerDelegate<RestoreRoleByRoleIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        IEnumerable<IAppAuthorizationRequirement> requirements =
        [
            new Authorizations.ValidateAccessToken.ValidateAccessTokenRequirement()
        ];

        foreach (var requirement in requirements)
        {
            var result = await _sender.Send(
                request: requirement,
                cancellationToken: cancellationToken
            );

            if (result.IsForbidden)
            {
                return new() { StatusCode = RestoreRoleByRoleIdResponseStatusCode.FORBIDDEN };
            }

            if (!result.IsAuthorized)
            {
                return new() { StatusCode = RestoreRoleByRoleIdResponseStatusCode.UN_AUTHORIZED };
            }
        }

        return await next();
    }
}
