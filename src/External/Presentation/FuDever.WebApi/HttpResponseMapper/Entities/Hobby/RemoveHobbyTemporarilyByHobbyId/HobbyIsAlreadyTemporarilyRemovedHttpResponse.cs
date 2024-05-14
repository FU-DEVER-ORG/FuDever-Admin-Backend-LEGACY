using FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyTemporarilyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyTemporarilyByHobbyId;

/// <summary>
///     Remove hobby temporarily by hobby
///     Id response status code - hobby is already
///     temporarily removed http response.
/// </summary>
internal sealed class HobbyIsAlreadyTemporarilyRemovedHttpResponse
    : RemoveHobbyTemporarilyByHobbyIdHttpResponse
{
    internal HobbyIsAlreadyTemporarilyRemovedHttpResponse(
        RemoveHobbyTemporarilyByHobbyIdRequest request,
        RemoveHobbyTemporarilyByHobbyIdResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found hobby with Id = {request.HobbyId} in temporarily removed storage."
        ];
    }
}
