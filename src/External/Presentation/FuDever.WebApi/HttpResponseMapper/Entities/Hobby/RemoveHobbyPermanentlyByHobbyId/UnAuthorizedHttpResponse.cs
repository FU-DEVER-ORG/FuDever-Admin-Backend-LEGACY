using FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Remove hobby permanently by hobby id http response
///     - un authorized http response.
/// </summary>
internal sealed class UnAuthorizedHttpResponse : RemoveHobbyPermanentlyByHobbyIdHttpResponse
{
    internal UnAuthorizedHttpResponse(RemoveHobbyPermanentlyByHobbyIdResponse response)
    {
        HttpCode = StatusCodes.Status401Unauthorized;
        AppCode = response.StatusCode.ToAppCode();
    }
}
