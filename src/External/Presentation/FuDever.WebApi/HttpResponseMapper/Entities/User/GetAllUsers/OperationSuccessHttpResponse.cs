using FuDever.Application.Features.User.GetAllUsers;
using FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers;

/// <summary>
///     Get all users response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllUsersHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllUsersResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundUsers;
    }
}
