using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser;

/// <summary>
///     Approve new user response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : ApproveNewUserHttpResponse
{
    internal OperationSuccessHttpResponse(ApproveNewUserResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
