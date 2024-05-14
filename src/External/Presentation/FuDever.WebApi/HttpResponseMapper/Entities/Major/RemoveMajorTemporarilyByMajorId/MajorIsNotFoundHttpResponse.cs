using FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorTemporarilyByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorTemporarilyByMajorId;

/// <summary>
///     Remove major temporarily by major
///     Id response status code - major is not
///     found http response.
/// </summary>
internal sealed class MajorIsNotFoundHttpResponse : RemoveMajorTemporarilyByMajorIdHttpResponse
{
    internal MajorIsNotFoundHttpResponse(
        RemoveMajorTemporarilyByMajorIdRequest request,
        RemoveMajorTemporarilyByMajorIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Major with Id = {request.MajorId} is not found."];
    }
}
