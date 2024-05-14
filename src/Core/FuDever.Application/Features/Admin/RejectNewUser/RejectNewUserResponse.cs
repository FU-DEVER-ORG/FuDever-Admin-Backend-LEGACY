namespace FuDever.Application.Features.Admin.RejectNewUser;

/// <summary>
///     Response of reject new user feature.
/// </summary>
public sealed class RejectNewUserResponse
{
    public RejectNewUserResponseStatusCode StatusCode { get; init; }
}
