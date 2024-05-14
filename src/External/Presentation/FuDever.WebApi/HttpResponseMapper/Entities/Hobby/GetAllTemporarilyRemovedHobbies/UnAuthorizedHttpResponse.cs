using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllTemporarilyRemovedHobbies.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllTemporarilyRemovedHobbies;

/// <summary>
///     Get all temporarily removed hobbies
///     response status code - un authorized
///     http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : GetAllTemporarilyRemovedHobbiesHttpResponse
{
    internal UnAuthorizedHttpResponse(GetAllTemporarilyRemovedHobbiesResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
