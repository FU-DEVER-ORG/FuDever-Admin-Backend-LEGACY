using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser;

/// <summary>
///     Reject new user response status code
///     - user is not found http response.
/// </summary>
internal sealed class UserIsNotFoundHttpResponse : RejectNewUserHttpResponse
{
    internal UserIsNotFoundHttpResponse(
        RejectNewUserRequest request,
        RejectNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User with user id = {request.UserId} is not found."];
    }
}
