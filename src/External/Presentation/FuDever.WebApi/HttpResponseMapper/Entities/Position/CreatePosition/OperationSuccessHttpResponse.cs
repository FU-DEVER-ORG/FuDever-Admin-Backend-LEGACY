using FuDever.Application.Features.Position.CreatePosition;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition;

/// <summary>
///     Create position response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreatePositionHttpResponse
{
    internal OperationSuccessHttpResponse(CreatePositionResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
