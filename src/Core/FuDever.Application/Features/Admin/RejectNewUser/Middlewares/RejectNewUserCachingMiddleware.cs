using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.User.GetAllUsers;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Admin.RejectNewUser.Middlewares;

/// <summary>
///     Reject new user request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RejectNewUserCachingMiddleware
    : IPipelineBehavior<RejectNewUserRequest, RejectNewUserResponse>,
        IRejectNewUserMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public RejectNewUserCachingMiddleware(ICacheHandler cacheHandler)
    {
        _cacheHandler = cacheHandler;
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
        var response = await next();

        if (response.StatusCode == RejectNewUserResponseStatusCode.OPERATION_SUCCESS)
        {
            await _cacheHandler.RemoveAsync(
                key: nameof(GetAllUsersRequest),
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
