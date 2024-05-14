using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser;

/// <summary>
///     Reject new user response status code
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : RejectNewUserHttpResponse
{
    internal InputValidationFailHttpResponse(RejectNewUserResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
