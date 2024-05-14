using FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorPermanentlyByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorPermanentlyByMajorId;

/// <summary>
///     Remove major permanently by major
///     Id response status code - major id not
///     found http response.
/// </summary>
internal sealed class MajorIsNotTemporarilyRemovedHttpResponse
    : RemoveMajorPermanentlyByMajorIdHttpResponse
{
    internal MajorIsNotTemporarilyRemovedHttpResponse(
        RemoveMajorPermanentlyByMajorIdRequest request,
        RemoveMajorPermanentlyByMajorIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Major with Id = {request.MajorId} is not found in temporarily removed storage."
        ];
    }
}
