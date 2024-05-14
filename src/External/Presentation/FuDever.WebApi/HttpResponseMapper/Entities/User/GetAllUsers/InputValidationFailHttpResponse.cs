using FuDever.Application.Features.User.GetAllUsers;
using FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers;

/// <summary>
///     Get all users response status code
///     - input validation fail http response.
/// </summary>
internal sealed class InputValidationFailHttpResponse : GetAllUsersHttpResponse
{
    internal InputValidationFailHttpResponse(GetAllUsersResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error. Please try again later."];
    }
}
