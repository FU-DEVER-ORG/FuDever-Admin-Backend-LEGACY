using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code
///     - user password is not valid
///     http response.
/// </summary>
internal sealed class UserPasswordIsNotValidHttpResponse : RegisterAsUserHttpResponse
{
    internal UserPasswordIsNotValidHttpResponse(RegisterAsUserResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Password is not valid."];
    }
}
