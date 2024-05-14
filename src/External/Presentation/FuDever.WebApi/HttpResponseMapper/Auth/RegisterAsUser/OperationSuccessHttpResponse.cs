using FuDever.Application.Features.Auth.RegisterAsUser;
using FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser;

/// <summary>
///     Register as user response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : RegisterAsUserHttpResponse
{
    internal OperationSuccessHttpResponse(RegisterAsUserResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
