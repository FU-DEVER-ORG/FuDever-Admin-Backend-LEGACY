using FuDever.Application.Features.Major.GetAllMajorsByMajorName;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajorsByMajorName.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajorsByMajorName;

/// <summary>
///     Get all majors by major name response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllMajorsByMajorNameHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllMajorsByMajorNameResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundMajors;
    }
}
