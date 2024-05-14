namespace FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

/// <summary>
///     Response for confirm user registration confirmed email
/// </summary>
public sealed class ConfirmUserRegistrationConfirmedEmailResponse
{
    public ConfirmUserRegistrationConfirmedEmailResponseStatusCode StatusCode { get; init; }

    public string ResponseBodyAsHtml { get; init; }
}
