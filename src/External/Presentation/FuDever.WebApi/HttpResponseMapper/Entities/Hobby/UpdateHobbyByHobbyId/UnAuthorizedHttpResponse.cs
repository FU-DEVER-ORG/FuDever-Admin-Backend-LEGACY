using FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.UpdateHobbyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Remove hobby temporarily by hobby id http response
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : UpdateHobbyByHobbyIdHttpResponse
{
    internal UnAuthorizedHttpResponse(UpdateHobbyByHobbyIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
