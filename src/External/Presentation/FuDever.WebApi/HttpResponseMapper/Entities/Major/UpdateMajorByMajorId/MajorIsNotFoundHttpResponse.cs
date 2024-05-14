using FuDever.Application.Features.Major.UpdateMajorByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId;

/// <summary>
///     Update major by major
///     Id response status code - major is not
///     found http response.
/// </summary>
internal sealed class MajorIsNotFoundHttpResponse : UpdateMajorByMajorIdHttpResponse
{
    internal MajorIsNotFoundHttpResponse(
        UpdateMajorByMajorIdRequest request,
        UpdateMajorByMajorIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Major with Id = {request.MajorId} is not found."];
    }
}
