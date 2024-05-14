using FuDever.Application.Features.Major.CreateMajor;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor;

/// <summary>
///     Create major response status code
///     - major already exists http response.
/// </summary>
internal sealed class MajorAlreadyExistsHttpResponse : CreateMajorHttpResponse
{
    internal MajorAlreadyExistsHttpResponse(
        CreateMajorRequest request,
        CreateMajorResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Major with name = {request.NewMajorName} already exists."];
    }
}
