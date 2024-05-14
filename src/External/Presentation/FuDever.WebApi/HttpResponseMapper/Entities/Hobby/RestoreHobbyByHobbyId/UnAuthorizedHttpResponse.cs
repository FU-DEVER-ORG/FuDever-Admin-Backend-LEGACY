using FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RestoreHobbyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RestoreHobbyByHobbyId;

/// <summary>
///     Remove hobby temporarily by hobby id http response
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RestoreHobbyByHobbyIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RestoreHobbyByHobbyIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
