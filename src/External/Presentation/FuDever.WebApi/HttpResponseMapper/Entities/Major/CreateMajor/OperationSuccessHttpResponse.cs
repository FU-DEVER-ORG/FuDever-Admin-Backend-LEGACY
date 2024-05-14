using FuDever.Application.Features.Major.CreateMajor;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor;

/// <summary>
///     Create major response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreateMajorHttpResponse
{
    internal OperationSuccessHttpResponse(CreateMajorResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
