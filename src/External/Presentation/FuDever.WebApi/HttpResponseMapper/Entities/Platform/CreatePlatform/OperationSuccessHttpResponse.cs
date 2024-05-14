using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform;

/// <summary>
///     Create platform response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreatePlatformHttpResponse
{
    internal OperationSuccessHttpResponse(CreatePlatformResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
