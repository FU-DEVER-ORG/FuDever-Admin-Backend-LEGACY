using FuDever.Application.Features.Auth.ChangingPassword;
using FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword;

/// <summary>
///     Changing password response status code -
///     database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : ChangingPasswordHttpResponse
{
    internal DatabaseOperationFailHttpResponse(ChangingPasswordResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
