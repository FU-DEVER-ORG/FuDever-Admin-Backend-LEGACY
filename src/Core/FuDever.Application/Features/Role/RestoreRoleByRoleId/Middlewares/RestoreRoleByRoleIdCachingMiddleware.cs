using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Role.GetAllRoles;
using FuDever.Application.Features.Role.GetAllRolesByRoleName;
using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.RestoreRoleByRoleId.Middlewares;

/// <summary>
///     Restore role by role id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class RestoreRoleByRoleIdCachingMiddleware
    : IPipelineBehavior<RestoreRoleByRoleIdRequest, RestoreRoleByRoleIdResponse>,
        IRestoreRoleByRoleIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public RestoreRoleByRoleIdCachingMiddleware(ICacheHandler cacheHandler, IUnitOfWork unitOfWork)
    {
        _cacheHandler = cacheHandler;
        _unitOfWork = unitOfWork;
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
        var response = await next();

        if (response.StatusCode == RestoreRoleByRoleIdResponseStatusCode.OPERATION_SUCCESS)
        {
            var foundRole =
                await _unitOfWork.RoleFeature.RestoreRoleByRoleId.Query.FindRoleByRoleIdForCacheClearing(
                    roleId: request.RoleId,
                    cancellationToken: cancellationToken
                );

            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllRolesByRoleNameRequest)}_param_{foundRole.Name.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllRolesRequest),
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllTemporarilyRemovedRolesRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
