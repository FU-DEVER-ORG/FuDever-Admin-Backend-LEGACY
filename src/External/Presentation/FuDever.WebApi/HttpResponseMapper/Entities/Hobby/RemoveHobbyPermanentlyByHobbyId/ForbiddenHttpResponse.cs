using FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Remove hobby permanently by hobby id http response
///     - forbidden http response.
/// </summary>
internal sealed class ForbiddenHttpResponse : RemoveHobbyPermanentlyByHobbyIdHttpResponse
{
    internal ForbiddenHttpResponse(RemoveHobbyPermanentlyByHobbyIdResponse response)
    {
        HttpCode = StatusCodes.Status403Forbidden;
        AppCode = response.StatusCode.ToAppCode();
    }
}
