using FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyTemporarilyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Remove hobby temporarily by hobby id http response
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RemoveHobbyTemporarilyByHobbyIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RemoveHobbyTemporarilyByHobbyIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
