using FuDever.Application.Features.Auth.Login;
using FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login;

internal sealed class UserIsAlreadyExpiredHttpResponse : LoginHttpResponse
{
    internal UserIsAlreadyExpiredHttpResponse(LoginRequest request, LoginResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"User account with username = {request.Username} is expired.",
            "Please contact with admin to know more information."
        ];
    }
}
