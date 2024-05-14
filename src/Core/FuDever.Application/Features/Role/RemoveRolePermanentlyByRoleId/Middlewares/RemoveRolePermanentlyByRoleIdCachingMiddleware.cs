using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using MediatR;

namespace FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId.Middlewares;

/// <summary>
///     Remove permanently role by
///     role id request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RemoveRolePermanentlyByRoleIdCachingMiddleware
    : IPipelineBehavior<
        RemoveRolePermanentlyByRoleIdRequest,
        RemoveRolePermanentlyByRoleIdResponse
    >,
        IRemoveRolePermanentlyByRoleIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;

    public RemoveRolePermanentlyByRoleIdCachingMiddleware(ICacheHandler cacheHandler)
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
    public async Task<RemoveRolePermanentlyByRoleIdResponse> Handle(
        RemoveRolePermanentlyByRoleIdRequest request,
        RequestHandlerDelegate<RemoveRolePermanentlyByRoleIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        var response = await next();

        if (
            response.StatusCode == RemoveRolePermanentlyByRoleIdResponseStatusCode.OPERATION_SUCCESS
        )
        {
            await _cacheHandler.RemoveAsync(
                key: nameof(GetAllTemporarilyRemovedRolesRequest),
                cancellationToken: cancellationToken
            );
        }

        return response;
    }
}
