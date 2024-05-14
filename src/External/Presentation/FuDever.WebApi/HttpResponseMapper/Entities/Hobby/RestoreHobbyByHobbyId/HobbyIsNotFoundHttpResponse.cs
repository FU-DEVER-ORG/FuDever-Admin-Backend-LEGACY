using FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RestoreHobbyByHobbyId.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RestoreHobbyByHobbyId;

/// <summary>
///     Restore hobby by hobby
///     Id response status code - hobby is not
///     found http response.
/// </summary>
internal sealed class HobbyIsNotFoundHttpResponse : RestoreHobbyByHobbyIdHttpResponse
{
    internal HobbyIsNotFoundHttpResponse(
        RestoreHobbyByHobbyIdRequest request,
        RestoreHobbyByHobbyIdResponse response
    )
    {
        HttpCode = StatusCodes.Status404NotFound;
        AppCode = response.StatusCode.ToAppCode();
        ErrorMessages = [$"Hobby with Id = {request.HobbyId} is not found."];
    }
}
