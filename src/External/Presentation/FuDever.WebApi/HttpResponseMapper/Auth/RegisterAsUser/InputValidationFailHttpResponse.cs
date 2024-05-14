using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : RegisterAsUserHttpResponse
{
    internal InputValidationFailHttpResponse(RegisterAsUserResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
