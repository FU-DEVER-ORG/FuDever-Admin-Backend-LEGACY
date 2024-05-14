using FuDever.Application.Features.Auth.Logout;
using FuDever.WebApi.HttpResponseMapper.Auth.Logout.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Logout;

/// <summary>
///     Logout response status code -
///     database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : LogoutHttpResponse
{
    internal DatabaseOperationFailHttpResponse(LogoutResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
