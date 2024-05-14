using FuDever.Application.Features.Hobby.GetAllHobbies;
using FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbies.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbies;

/// <summary>
///     Get all hobbies response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllHobbiesHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllHobbiesResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundHobbies;
    }
}
