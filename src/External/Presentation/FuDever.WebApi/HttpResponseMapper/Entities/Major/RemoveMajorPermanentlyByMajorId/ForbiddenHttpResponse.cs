using FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorPermanentlyByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorPermanentlyByMajorId;

/// <summary>
///     Remove major permanently by major
///     Id response status code
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RemoveMajorPermanentlyByMajorIdHttpResponse
{
    internal ForbiddenHttpResponse(RemoveMajorPermanentlyByMajorIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
