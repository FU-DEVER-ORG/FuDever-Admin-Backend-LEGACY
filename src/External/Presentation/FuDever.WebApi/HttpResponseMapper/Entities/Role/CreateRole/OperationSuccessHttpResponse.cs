using FuDever.Application.Features.Role.CreateRole;
using FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole;

/// <summary>
///     Create role response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : CreateRoleHttpResponse
{
    internal OperationSuccessHttpResponse(CreateRoleResponse response)
    {
        HttpCode = StatusCodes.Status201Created;
        AppCode = response.StatusCode.ToAppCode();
    }
}
