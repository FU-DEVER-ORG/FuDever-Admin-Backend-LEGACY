using FuDever.Application.Features.Hobby.CreateHobby;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby;

/// <summary>
///     Create hobby response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreateHobbyHttpResponse
{
    internal OperationSuccessHttpResponse(CreateHobbyResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
