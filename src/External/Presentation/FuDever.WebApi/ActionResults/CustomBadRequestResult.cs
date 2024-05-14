using System.Threading.Tasks;
using FuDever.WebApi.AppCodes;
using FuDever.WebApi.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.ActionResults;

/// <summary>
///     Represent custom validation problem details result.
/// </summary>
internal sealed class CustomBadRequestResult : IActionResult
{
    public async Task ExecuteResultAsync(ActionContext context)
    {
        CommonResponse problemDetails =
            new()
            {
                AppCode = (int)OtherAppCode.INVALID_INPUTS,
                ErrorMessages = ["Invalid inputs are found."]
            };

        ObjectResult badResult =
            new(value: problemDetails) { StatusCode = StatusCodes.Status400BadRequest };

        await badResult.ExecuteResultAsync(context: context);
    }
}
