using FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbiesByHobbyName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbiesByHobbyName;

/// <summary>
///     Get all hobbies by hobby name response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllHobbiesByHobbyNameHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllHobbiesByHobbyNameResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundHobbies;
    }
}
