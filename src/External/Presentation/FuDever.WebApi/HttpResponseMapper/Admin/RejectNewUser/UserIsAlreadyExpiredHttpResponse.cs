using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser;

internal sealed class UserIsAlreadyExpiredHttpResponse : RejectNewUserHttpResponse
{
    internal UserIsAlreadyExpiredHttpResponse(
        RejectNewUserRequest request,
        RejectNewUserResponse response
    )
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"User account with user id = {request.UserId} is already expired."];
    }
}
