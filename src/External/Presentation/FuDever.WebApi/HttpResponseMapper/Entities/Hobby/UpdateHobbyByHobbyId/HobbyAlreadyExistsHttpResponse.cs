using FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.UpdateHobbyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.UpdateHobbyByHobbyId;

/// <summary>
///     Update hobby by hobby id response
///     status code - hobby already exists
///     http response.
/// </summary>
internal sealed class HobbyAlreadyExistsHttpResponse : UpdateHobbyByHobbyIdHttpResponse
{
    internal HobbyAlreadyExistsHttpResponse(
        UpdateHobbyByHobbyIdRequest request,
        UpdateHobbyByHobbyIdResponse response
    )
    {
        HttpCode = StatusCodes.Status409Conflict;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Hobby with name = {request.NewHobbyName} already exists."];
    }
}
