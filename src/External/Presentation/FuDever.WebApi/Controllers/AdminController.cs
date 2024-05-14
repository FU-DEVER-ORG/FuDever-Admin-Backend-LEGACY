using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Admin.ApproveNewUser;
using FuDever.Application.Features.Admin.RejectNewUser;
using FuDever.WebApi.HttpResponseMapper.Others;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.Controllers;

[Consumes(contentType: MediaTypeNames.Application.Json)]
[Produces(contentType: MediaTypeNames.Application.Json)]
[ApiController]
[Route(template: "api/[controller]")]
public sealed class AdminController : ControllerBase
{
    private readonly ISender _sender;
    private readonly HttpResponseMapperManager _httpResponseMapperManager;

    public AdminController(ISender sender, HttpResponseMapperManager httpResponseMapperManager)
    {
        _sender = sender;
        _httpResponseMapperManager = httpResponseMapperManager;
    }

    /// <summary>
    ///     Endpoint for approving user.
    /// </summary>
    /// <param name="userId">
    ///     Id of user to approve.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    ///     App code.
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Admin/approve-user/{userId:guid}
    ///
    /// </remarks>
    [HttpPost(template: "approve-user/{userId:guid}")]
    public async Task<IActionResult> ApproveNewUserAsync(
        [FromRoute] [Required] Guid userId,
        CancellationToken cancellationToken
    )
    {
        // Approve new user request init.
        ApproveNewUserRequest featureRequest = new() { UserId = userId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Admin.ApproveNewUser.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Endpoint for rejecting user.
    /// </summary>
    /// <param name="userId">
    ///     Id of user to reject.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    ///     App code.
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Admin/reject-user/{userId:guid}
    ///
    /// </remarks>
    [HttpPost(template: "reject-user/{userId:guid}")]
    public async Task<IActionResult> RejectNewUserAsync(
        [FromRoute] [Required] Guid userId,
        CancellationToken cancellationToken
    )
    {
        // Reject new user request init.
        RejectNewUserRequest featureRequest = new() { UserId = userId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Admin.RejectNewUser.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }
}
