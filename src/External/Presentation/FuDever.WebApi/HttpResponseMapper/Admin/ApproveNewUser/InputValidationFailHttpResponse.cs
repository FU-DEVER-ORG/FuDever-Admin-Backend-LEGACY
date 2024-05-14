using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser;

/// <summary>
///     Approve new user response status code
///     - input validation fail http
///     response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : ApproveNewUserHttpResponse
{
    internal InputValidationFailHttpResponse(ApproveNewUserResponse response)
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Input validation fail. Please check your inputs and try again."];
    }
}
