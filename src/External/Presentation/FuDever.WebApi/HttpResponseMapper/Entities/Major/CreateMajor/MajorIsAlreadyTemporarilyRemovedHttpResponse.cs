using FuDever.Application.Features.Major.CreateMajor;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor;

/// <summary>
///     Create major response status code
///     - major is already temporarily removed
///     http response.
/// </summary>
internal sealed class MajorIsAlreadyTemporarilyRemovedHttpResponse : CreateMajorHttpResponse
{
    internal MajorIsAlreadyTemporarilyRemovedHttpResponse(
        CreateMajorRequest request,
        CreateMajorResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found major with name = {request.NewMajorName} in temporarily removed storage."
        ];
    }
}
