using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllTemporarilyRemovedHobbies.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllTemporarilyRemovedHobbies;

/// <summary>
///     Get all temporarily removed hobbies
///     response status code - forbidden http
///     response.
/// </summary>
internal sealed class ForbiddenHttpResponse : GetAllTemporarilyRemovedHobbiesHttpResponse
{
    internal ForbiddenHttpResponse(GetAllTemporarilyRemovedHobbiesResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
