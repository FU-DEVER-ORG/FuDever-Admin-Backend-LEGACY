using FuDever.Application.Features.Major.CreateMajor;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor;

/// <summary>
///     Create major response status code
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : CreateMajorHttpResponse
{
    internal UnAuthorizedHttpResponse(CreateMajorResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
