using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser;

/// <summary>
///     Reject new user response status code
///     - user is already approved http response.
/// </summary>
internal sealed class UserIsAlreadyApprovedHttpResponse : RejectNewUserHttpResponse
{
    internal UserIsAlreadyApprovedHttpResponse(
        RejectNewUserRequest request,
        RejectNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User account with user id = {request.UserId} is already approved."];
    }
}
