using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Role.GetAllRoles;
using FuDever.Application.Features.Role.GetAllRolesByRoleName;
using FuDever.Application.Shared.Attributes;
using FuDever.Application.Shared.Caching;
using FuDever.Domain.UnitOfWorks;
using MediatR;

namespace FuDever.Application.Features.Role.UpdateRoleByRoleId.Middlewares;

/// <summary>
///     Update role by role id
///     request caching middleware.
/// </summary>
[FeatureMiddlewareOrder(value: 3)]
internal sealed class UpdateRoleByRoleIdCachingMiddleware
    : IPipelineBehavior<UpdateRoleByRoleIdRequest, UpdateRoleByRoleIdResponse>,
        IUpdateRoleByRoleIdMiddleware
{
    private readonly ICacheHandler _cacheHandler;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRoleByRoleIdCachingMiddleware(ICacheHandler cacheHandler, IUnitOfWork unitOfWork)
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
    public async Task<UpdateRoleByRoleIdResponse> Handle(
        UpdateRoleByRoleIdRequest request,
        RequestHandlerDelegate<UpdateRoleByRoleIdResponse> next,
        CancellationToken cancellationToken
    )
    {
        // Finding current role by role id.
        var foundRole =
            await _unitOfWork.RoleFeature.UpdateRoleByRoleId.Query.FindRoleByRoleIdForCacheClearing(
                roleId: request.RoleId,
                cancellationToken: cancellationToken
            );

        // Role is found by role id.
        if (!Equals(objA: foundRole, objB: default))
        {
            await _cacheHandler.RemoveAsync(
                key: $"{nameof(GetAllRolesByRoleNameRequest)}_param_{foundRole.Name.ToLower()}",
                cancellationToken: cancellationToken
            );
        }

        var response = await next();

        if (response.StatusCode == UpdateRoleByRoleIdResponseStatusCode.OPERATION_SUCCESS)
        {
            await Task.WhenAll(
                _cacheHandler.RemoveAsync(
                    key: $"{nameof(GetAllRolesByRoleNameRequest)}_param_{request.NewRoleName.ToLower()}",
                    cancellationToken: cancellationToken
                ),
                _cacheHandler.RemoveAsync(
                    key: nameof(GetAllRolesRequest),
                    cancellationToken: cancellationToken
                )
            );
        }

        return response;
    }
}
