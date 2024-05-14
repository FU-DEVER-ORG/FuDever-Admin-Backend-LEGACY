using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code
///     - sending user confirmation mail fail
///     http response.
/// </summary>
internal sealed class SendingUserConfirmationMailFailHttpResponse : RegisterAsUserHttpResponse
{
    internal SendingUserConfirmationMailFailHttpResponse(RegisterAsUserResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Sending confirmation email fail !!", "Please contact admin for support."];
    }
}
