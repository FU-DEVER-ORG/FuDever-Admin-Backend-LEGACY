using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;
using FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail;

/// <summary>
///     Confirm user registration confirmed email
///     response status code -
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse
    : ResendUserRegistrationConfirmedEmailHttpResponse
{
    internal OperationSuccessHttpResponse(ResendUserRegistrationConfirmedEmailResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
