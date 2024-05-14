using FuDever.Application.Features.Hobby.CreateHobby;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby;

/// <summary>
///     Create hobby response status code
///     - hobby is already temporarily removed
///     http response.
/// </summary>
internal sealed class HobbyIsAlreadyTemporarilyRemovedHttpResponse : CreateHobbyHttpResponse
{
    internal HobbyIsAlreadyTemporarilyRemovedHttpResponse(
        CreateHobbyRequest request,
        CreateHobbyResponse response
    )
    {
        HttpCode = StatusCodes.Status400BadRequest;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages =
        [
            $"Found hobby with name = {request.NewHobbyName} in temporarily removed storage."
        ];
    }
}
