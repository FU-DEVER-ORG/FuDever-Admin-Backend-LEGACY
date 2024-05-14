using FuDever.Application.Features.Hobby.CreateHobby;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby;

/// <summary>
///     Create hobby response status code
///     - hobby already exists http response.
/// </summary>
internal sealed class HobbyAlreadyExistsHttpResponse : CreateHobbyHttpResponse
{
    internal HobbyAlreadyExistsHttpResponse(
        CreateHobbyRequest request,
        CreateHobbyResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Hobby with name = {request.NewHobbyName} already exists."];
    }
}
