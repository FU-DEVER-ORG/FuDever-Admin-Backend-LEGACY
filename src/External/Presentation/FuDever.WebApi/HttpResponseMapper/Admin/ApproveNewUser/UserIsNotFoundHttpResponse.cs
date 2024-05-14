using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser;

/// <summary>
///     Approve new user response status code
///     - user is not found http response.
/// </summary>
internal sealed class UserIsNotFoundHttpResponse : ApproveNewUserHttpResponse
{
    internal UserIsNotFoundHttpResponse(
        ApproveNewUserRequest request,
        ApproveNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with user id = {request.UserId} is not found."];
    }
}
