using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;
using Microsoft.AspNetCore.Http;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser;

/// <summary>
///     Reject new user response status code
///     - operation success http response.
/// </summary>
internal sealed class OperationSuccessHttpResponse : RejectNewUserHttpResponse
{
    internal OperationSuccessHttpResponse(RejectNewUserResponse response)
    {
        HttpCode = StatusCodes.Status200OK;
        AppCode = response.StatusCode.ToAppCode();
    }
}
