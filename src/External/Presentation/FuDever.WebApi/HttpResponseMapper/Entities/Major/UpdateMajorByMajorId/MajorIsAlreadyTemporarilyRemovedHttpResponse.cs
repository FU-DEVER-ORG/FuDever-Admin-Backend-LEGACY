using FuDever.Application.Features.Major.UpdateMajorByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId;

/// <summary>
///     Update major by major
///     Id response status code - major is already
///     temporarily removed http response.
/// </summary>
internal sealed class MajorIsAlreadyTemporarilyRemovedHttpResponse
    : UpdateMajorByMajorIdHttpResponse
{
    internal MajorIsAlreadyTemporarilyRemovedHttpResponse(
        UpdateMajorByMajorIdRequest request,
        UpdateMajorByMajorIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found major with Id = {request.MajorId} in temporarily removed storage."
        ];
    }
}
