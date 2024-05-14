using FuDever.Application.Features.Platform.GetAllPlatforms;
using FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatforms.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatforms;

/// <summary>
///     Get all platforms response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllPlatformsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllPlatformsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundPlatforms;
    }
}
