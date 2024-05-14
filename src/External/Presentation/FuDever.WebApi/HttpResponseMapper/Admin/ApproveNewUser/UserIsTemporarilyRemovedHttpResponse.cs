using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser;

/// <summary>
///     Approve new user response status code
///     - user is temporarily removed
///     http response.
/// </summary>
internal sealed class UserIsTemporarilyRemovedHttpResponse : ApproveNewUserHttpResponse
{
    internal UserIsTemporarilyRemovedHttpResponse(
        ApproveNewUserRequest request,
        ApproveNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"User with user id = {request.UserId} has already been banned or blocked by Admin.",
            "Please contact with admin to recover your account."
        ];
    }
}
