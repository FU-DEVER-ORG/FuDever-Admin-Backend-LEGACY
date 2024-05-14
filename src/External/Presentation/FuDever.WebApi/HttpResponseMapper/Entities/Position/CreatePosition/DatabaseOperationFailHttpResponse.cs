using FuDever.Application.Features.Position.CreatePosition;
using FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition;

/// <summary>
///     Create position response status code
///     - database operation fail http response.
/// </summary>
internal sealed class DatabaseOperationFailHttpResponse : CreatePositionHttpResponse
{
    internal DatabaseOperationFailHttpResponse(CreatePositionResponse response)
    {
        HttpCode = StatusCodes.Status500InternalServerError;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = ["Server error !!!"];
    }
}
