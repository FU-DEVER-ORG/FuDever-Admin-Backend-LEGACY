using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Platform.CreatePlatform;
using FuDever.Application.Features.Platform.GetAllPlatforms;
using FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;
using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;
using FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;
using FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;
using FuDever.Application.Features.Platform.RestorePlatformByPlatformId;
using FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;
using FuDever.WebApi.DTOs.Platform.Incomings;
using FuDever.WebApi.HttpResponseMapper.Others;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.Controllers;

[Consumes(contentType: MediaTypeNames.Application.Json)]
[Produces(contentType: MediaTypeNames.Application.Json)]
[ApiController]
[Route(template: "api/[controller]")]
public sealed class PlatformController : ControllerBase
{
    private readonly ISender _sender;
    private readonly HttpResponseMapperManager _httpResponseMapperManager;

    public PlatformController(ISender sender, HttpResponseMapperManager httpResponseMapperManager)
    {
        _sender = sender;
        _httpResponseMapperManager = httpResponseMapperManager;
    }

    /// <summary>
    ///     Get all platforms which are not temporarily removed.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of platforms.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Platform/all
    ///
    /// </remarks>
    [HttpGet(template: "all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        // Get all platforms which are not temporarily removed.
        GetAllPlatformsRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.GetAllPlatforms.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all platforms having name equal to
    ///     input <paramref name="platformName"/> in lowercase.
    /// </summary>
    /// <param name="platformName">
    ///     Use to search for platforms with similar name.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of platforms having name equal to
    ///     input <paramref name="platformName"/>.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Platform?name={platformName}
    ///
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetAllByNameAsync(
        [FromQuery(Name = "name")] [Required] string platformName,
        CancellationToken cancellationToken
    )
    {
        platformName = platformName.Trim();

        // Find platform by name.
        GetAllPlatformsByPlatformNameRequest featureRequest =
            new() { PlatformName = platformName, CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.GetAllPlatformsByPlatformName.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Create new platform with credentials
    ///     from input <paramref name="dto"/>.
    /// </summary>
    /// <param name="dto">
    ///     Containing credentials that are
    ///     used to create a new platform.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Platform
    ///     {
    ///         "platformName": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreatePlatformDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Create platform
        CreatePlatformRequest featureRequest = new() { NewPlatformName = dto.PlatformName };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.CreatePlatform.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        if (apiResponse.HttpCode == StatusCodes.Status201Created)
        {
            return Created(
                uri: $"{HttpContext.Request.Path}?name={dto.PlatformName}",
                value: apiResponse
            );
        }

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///    Temporarily remove an existed platform
    ///    by input <paramref name="platformId"/>.
    /// </summary>
    /// <param name="platformId">
    ///     Id of platform to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Platform/{platformId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "{platformId:guid}")]
    public async Task<IActionResult> RemoveTemporarilyByIdAsync(
        [FromRoute] [Required] Guid platformId,
        CancellationToken cancellationToken
    )
    {
        // Remove platform temporarily by platform id.
        RemovePlatformTemporarilyByPlatformIdRequest featureRequest =
            new() { PlatformId = platformId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.RemovePlatformTemporarilyByPlatformId.Resolve(
                statusCode: featureResponse.StatusCode
            )
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Update an existed platform with credentials.
    /// </summary>
    /// <param name="platformId">
    ///     Id of platform to search for.
    /// </param>
    /// <param name="dto">
    ///     Containing credentials that are used to change the found platform.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Platform/{platformId:guid}
    ///     {
    ///         "newPlatformName" : "string"
    ///     }
    ///
    /// </remarks>
    [HttpPatch(template: "{platformId:guid}")]
    public async Task<IActionResult> UpdateByIdAsync(
        [FromRoute] [Required] Guid platformId,
        [FromBody] UpdatePlatformDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Update platform by platform id.
        UpdatePlatformByPlatformIdRequest featureRequest =
            new() { NewPlatformName = dto.NewPlatformName, PlatformId = platformId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.UpdatePlatformByPlatformId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all platforms that have been temporarily removed.
    /// </summary>
    /// <returns>
    ///     A list of temporarily removed platforms.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Platform/remove/all
    ///
    /// </remarks>
    [HttpGet(template: "remove/all")]
    public async Task<IActionResult> GetAllTemporarilyRemovedAsync(
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed platforms.
        GetAllTemporarilyRemovedPlatformsRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.GetAllTemporarilyRemovedPlatforms.Resolve(
                statusCode: featureResponse.StatusCode
            )
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Permanently remove an existed temporarily removed platform.
    ///     by input platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Id of platform to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Platform/remove/{platformId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "remove/{platformId:guid}")]
    public async Task<IActionResult> RemovePermanentlyByIdAsync(
        [FromRoute] [Required] Guid platformId,
        CancellationToken cancellationToken
    )
    {
        RemovePlatformPermanentlyByPlatformIdRequest featureRequest =
            new() { PlatformId = platformId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.RemovePlatformPermanentlyByPlatformId.Resolve(
                statusCode: featureResponse.StatusCode
            )
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Restore a temporarily removed platform by input platform id.
    /// </summary>
    /// <param name="platformId">
    ///     Id of platform to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Platform/remove/{platformId:guid}
    ///
    /// </remarks>
    [HttpPatch(template: "remove/{platformId:guid}")]
    public async Task<IActionResult> RestoreByIdAsync(
        [FromRoute] [Required] Guid platformId,
        CancellationToken cancellationToken
    )
    {
        // Restore platform by platform id.
        RestorePlatformByPlatformIdRequest featureRequest = new() { PlatformId = platformId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Platform.RestorePlatformByPlatformId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get user id from access token.
    /// </summary>
    /// <returns>
    ///     User id.
    /// </returns>
    private Guid GetUserIdFromAccessToken()
    {
        // get the sub claim and try parse to the user id.
        var subClaim = HttpContext.User.FindFirstValue(claimType: JwtRegisteredClaimNames.Sub);
        var userId = Guid.Empty;

        if (Guid.TryParse(input: subClaim, result: out var newUserId))
        {
            userId = newUserId;
        }

        return userId;
    }
}
