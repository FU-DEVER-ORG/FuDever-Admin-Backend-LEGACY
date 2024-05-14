using FuDever.Application.Features.Major.RestoreMajorByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId;

/// <summary>
///     Restore major by major
///     Id response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RestoreMajorByMajorIdHttpResponse
{
    internal ForbiddenHttpResponse(RestoreMajorByMajorIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
