using FuDever.Application.Features.Major.UpdateMajorByMajorId;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId;

/// <summary>
///     Update major by major id response
///     status code - major already exists
///     http response.
/// </summary>
internal sealed class MajorAlreadyExistsHttpResponse : UpdateMajorByMajorIdHttpResponse
{
    internal MajorAlreadyExistsHttpResponse(
        UpdateMajorByMajorIdRequest request,
        UpdateMajorByMajorIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Major with name = {request.NewMajorName} already exists."];
    }
}
