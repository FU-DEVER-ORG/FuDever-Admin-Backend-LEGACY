using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser;

internal sealed class UserIsAlreadyExpiredHttpResponse : ApproveNewUserHttpResponse
{
    internal UserIsAlreadyExpiredHttpResponse(
        ApproveNewUserRequest request,
        ApproveNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User account with user id = {request.UserId} is already expired."];
    }
}
