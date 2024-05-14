using FuDever.Application.Features.User.GetAllUsers.Middlewares;
using MediatR;

namespace FuDever.Application.Features.User.GetAllUsers;

/// <summary>
///     Get all users request.
/// </summary>
public sealed class GetAllUsersRequest : IRequest<GetAllUsersResponse>, IGetAllUsersMiddleware
{
    /// <summary>
    ///     How long the result should live in cache.
    /// </summary>
    /// <remarks>
    ///     Don't give this property a value when don't
    ///     want the result to be cached.
    /// </remarks>
    public int CacheExpiredTime { get; init; }
}
