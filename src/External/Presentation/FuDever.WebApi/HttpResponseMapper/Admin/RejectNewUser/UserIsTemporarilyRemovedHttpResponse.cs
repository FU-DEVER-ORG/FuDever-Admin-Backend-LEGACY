using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser;

/// <summary>
///     Reject new user response status code
///     - user is temporarily removed
///     http response.
/// </summary>
internal sealed class UserIsTemporarilyRemovedHttpResponse : RejectNewUserHttpResponse
{
    internal UserIsTemporarilyRemovedHttpResponse(
        RejectNewUserRequest request,
        RejectNewUserResponse response
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
