using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Authorization;
using MediatR;

namespace FuDever.Application.Features.Admin.RejectNewUser.Middlewares;

/// <summary>
///     Approve new user request authorization middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 1)]
internal sealed class RejectNewUserAuthorizationMiddleware
    : IPipelineBehavior<RejectNewUserRequest, RejectNewUserResponse>,
        IRejectNewUserMiddleware
{
    private readonly ISender _sender;

    public RejectNewUserAuthorizationMiddleware(ISender sender)
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
    public async Task<RejectNewUserResponse> Handle(
        RejectNewUserRequest request,
        RequestHandlerDelegate<RejectNewUserResponse> next,
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
                return new() { StatusCode = RejectNewUserResponseStatusCode.FORBIDDEN };
            }

            if (!result.IsAuthorized)
            {
                return new() { StatusCode = RejectNewUserResponseStatusCode.UN_AUTHORIZED };
            }
        }

        return await next();
    }
}
