using FuDever.Application.Features.Major.GetAllMajors;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajors.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajors;

/// <summary>
///     Get all majors response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllMajorsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllMajorsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundMajors;
    }
}
