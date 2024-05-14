using FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId;

/// <summary>
///     Remove hobby permanently by hobby
///     Id response status code - hobby id not
///     found http response.
/// </summary>
internal sealed class HobbyIsNotTemporarilyRemovedHttpResponse
    : RemoveHobbyPermanentlyByHobbyIdHttpResponse
{
    internal HobbyIsNotTemporarilyRemovedHttpResponse(
        RemoveHobbyPermanentlyByHobbyIdRequest request,
        RemoveHobbyPermanentlyByHobbyIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Hobby with Id = {request.HobbyId} is not found in temporarily removed storage."
        ];
    }
}
