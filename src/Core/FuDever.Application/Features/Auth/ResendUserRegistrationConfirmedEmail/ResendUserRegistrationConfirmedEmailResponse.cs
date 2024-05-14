namespace FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Response for resending user registration confirmed email.
/// </summary>
public sealed class ResendUserRegistrationConfirmedEmailResponse
{
    public ResendUserRegistrationConfirmedEmailResponseStatusCode StatusCode { get; init; }
}
