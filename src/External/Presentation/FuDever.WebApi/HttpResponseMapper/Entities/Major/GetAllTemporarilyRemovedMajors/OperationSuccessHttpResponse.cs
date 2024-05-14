using FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;
using FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors;

/// <summary>
///     Get all temporarily removed majors response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : GetAllTemporarilyRemovedMajorsHttpResponse
{
    internal OperationSuccessHttpResponse(GetAllTemporarilyRemovedMajorsResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
        Body = response.FoundTemporarilyRemovedMajors;
    }
}
