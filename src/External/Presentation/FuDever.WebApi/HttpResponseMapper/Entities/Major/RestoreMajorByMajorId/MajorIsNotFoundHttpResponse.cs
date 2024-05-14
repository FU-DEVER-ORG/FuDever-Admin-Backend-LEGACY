using FuDever.Application.Features.Major.RestoreMajorByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId;

/// <summary>
///     Restore major by major
///     Id response status code - major is not
///     found http response.
/// </summary>
internal sealed class MajorIsNotFoundHttpResponse : RestoreMajorByMajorIdHttpResponse
{
    internal MajorIsNotFoundHttpResponse(
        RestoreMajorByMajorIdRequest request,
        RestoreMajorByMajorIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Major with Id = {request.MajorId} is not found."];
    }
}
