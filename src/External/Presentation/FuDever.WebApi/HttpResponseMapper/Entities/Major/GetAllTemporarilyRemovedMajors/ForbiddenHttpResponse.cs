using FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors;

/// <summary>
///     Get all temporarily removed majors response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : GetAllTemporarilyRemovedMajorsHttpResponse
{
    internal ForbiddenHttpResponse(GetAllTemporarilyRemovedMajorsResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
