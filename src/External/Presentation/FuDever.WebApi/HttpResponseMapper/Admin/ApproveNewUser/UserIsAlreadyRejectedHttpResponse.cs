using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser;

/// <summary>
///     Approve new user response status code
///     - user is already rejected http response.
/// </summary>
internal sealed class UserIsAlreadyRejectedHttpResponse : ApproveNewUserHttpResponse
{
    internal UserIsAlreadyRejectedHttpResponse(
        ApproveNewUserRequest request,
        ApproveNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User account with user id = {request.UserId} is already rejected."];
    }
}
