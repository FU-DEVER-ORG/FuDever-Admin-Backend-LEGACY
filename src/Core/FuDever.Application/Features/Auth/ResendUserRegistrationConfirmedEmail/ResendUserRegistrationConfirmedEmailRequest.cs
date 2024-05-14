using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Request for resending user registration confirmed email.
/// </summary>
public sealed class ResendUserRegistrationConfirmedEmailRequest
    : IRequest<ResendUserRegistrationConfirmedEmailResponse>,
        IResendUserRegistrationConfirmedEmailMiddleware
{
    public string Username { get; init; }

    /// <summary>
    ///     How long the result should live in cache.
    /// </summary>
    /// <remarks>
    ///     Don't give this property a value when don't
    ///     want the result to be cached.
    /// </remarks>
    public int CacheExpiredTime { get; init; }
}
