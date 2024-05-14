using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail.Middlewares;
using MediatR;

namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Request for confirm user registration confirmed email
/// </summary>
public sealed class ConfirmUserRegistrationConfirmedEmailRequest
    : IRequest<ConfirmUserRegistrationConfirmedEmailResponse>,
        IConfirmUserRegistrationConfirmedEmailMiddleware
{
    public string UserRegistrationEmailConfirmedTokenAsBase64 { get; init; }

    /// <summary>
    ///     How long the result should live in cache.
    /// </summary>
    /// <remarks>
    ///     Don't give this property a value when don't
    ///     want the result to be cached.
    /// </remarks>
    public int CacheExpiredTime { get; init; }
}
