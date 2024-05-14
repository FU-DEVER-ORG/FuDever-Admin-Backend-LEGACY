using FuDever.Application.Features.Major.RestoreMajorByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId;

/// <summary>
///     Restore major by major
///     Id response status code - major id not
///     found http response.
/// </summary>
internal sealed class MajorIsNotTemporarilyRemovedHttpResponse : RestoreMajorByMajorIdHttpResponse
{
    internal MajorIsNotTemporarilyRemovedHttpResponse(
        RestoreMajorByMajorIdRequest request,
        RestoreMajorByMajorIdResponse response
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
