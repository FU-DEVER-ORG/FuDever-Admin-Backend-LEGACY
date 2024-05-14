using FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorTemporarilyByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorTemporarilyByMajorId;

/// <summary>
///     Remove major temporarily by major
///     Id response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RemoveMajorTemporarilyByMajorIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RemoveMajorTemporarilyByMajorIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
