﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Role.CreateRole;
using FuDever.Application.Features.Role.GetAllRoles;
using FuDever.Application.Features.Role.GetAllRolesByRoleName;
using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;
using FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;
using FuDever.Application.Features.Role.RemoveRoleTemporarilyByRoleId;
using FuDever.Application.Features.Role.RestoreRoleByRoleId;
using FuDever.Application.Features.Role.UpdateRoleByRoleId;
using FuDever.WebApi.DTOs.Role.Incomings;
using FuDever.WebApi.HttpResponseMapper.Others;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.Controllers;

[Consumes(contentType: MediaTypeNames.Application.Json)]
[Produces(contentType: MediaTypeNames.Application.Json)]
[ApiController]
[Route(template: "api/[controller]")]
public sealed class RoleController : ControllerBase
{
    private readonly ISender _sender;
    private readonly HttpResponseMapperManager _httpResponseMapperManager;

    public RoleController(ISender sender, HttpResponseMapperManager httpResponseMapperManager)
    {
        _sender = sender;
        _httpResponseMapperManager = httpResponseMapperManager;
    }

    /// <summary>
    ///     Get all roles which are not temporarily removed.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of roles.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Role/all
    ///
    /// </remarks>
    [HttpGet(template: "all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        // Get all roles which are not temporarily removed.
        GetAllRolesRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.GetAllRoles.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all roles having name equal to
    ///     input <paramref name="roleName"/> in lowercase.
    /// </summary>
    /// <param name="roleName">
    ///     Use to search for roles with similar name.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of roles having name equal to
    ///     input <paramref name="roleName"/>.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Role?name={roleName}
    ///
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetAllByNameAsync(
        [FromQuery(Name = "name")] [Required] string roleName,
        CancellationToken cancellationToken
    )
    {
        roleName = roleName.Trim();

        // Find role by name.
        GetAllRolesByRoleNameRequest featureRequest =
            new() { RoleName = roleName, CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.GetAllRolesByRoleName.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Create new role with credentials
    ///     from input <paramref name="dto"/>.
    /// </summary>
    /// <param name="dto">
    ///     Containing credentials that are
    ///     used to create a new role.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Role
    ///     {
    ///         "roleName": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateRoleDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Create role
        CreateRoleRequest featureRequest = new() { NewRoleName = dto.RoleName };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.CreateRole.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        if (apiResponse.HttpCode == StatusCodes.Status201Created)
        {
            return Created(
                uri: $"{HttpContext.Request.Path}?name={dto.RoleName}",
                value: apiResponse
            );
        }

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///    Temporarily remove an existed role
    ///    by input <paramref name="roleId"/>.
    /// </summary>
    /// <param name="roleId">
    ///     Id of role to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Role/{roleId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "{roleId:guid}")]
    public async Task<IActionResult> RemoveTemporarilyByIdAsync(
        [FromRoute] [Required] Guid roleId,
        CancellationToken cancellationToken
    )
    {
        // Remove role temporarily by role id.
        RemoveRoleTemporarilyByRoleIdRequest featureRequest = new() { RoleId = roleId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.RemoveRoleTemporarilyByRoleId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Update an existed role with credentials.
    /// </summary>
    /// <param name="roleId">
    ///     Id of role to search for.
    /// </param>
    /// <param name="dto">
    ///     Containing credentials that are used to change the found role.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Role/{roleId:guid}
    ///     {
    ///         "newRoleName" : "string"
    ///     }
    ///
    /// </remarks>
    [HttpPatch(template: "{roleId:guid}")]
    public async Task<IActionResult> UpdateByIdAsync(
        [FromRoute] [Required] Guid roleId,
        [FromBody] UpdateRoleDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Update role by role id.
        UpdateRoleByRoleIdRequest featureRequest =
            new() { NewRoleName = dto.NewRoleName, RoleId = roleId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.UpdateRoleByRoleId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all roles that have been temporarily removed.
    /// </summary>
    /// <returns>
    ///     A list of temporarily removed roles.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Role/remove/all
    ///
    /// </remarks>
    [HttpGet(template: "remove/all")]
    public async Task<IActionResult> GetAllTemporarilyRemovedAsync(
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed roles.
        GetAllTemporarilyRemovedRolesRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.GetAllTemporarilyRemovedRoles.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Permanently remove an existed temporarily removed role.
    ///     by input role id.
    /// </summary>
    /// <param name="roleId">
    ///     Id of role to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Role/remove/{roleId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "remove/{roleId:guid}")]
    public async Task<IActionResult> RemovePermanentlyByIdAsync(
        [FromRoute] [Required] Guid roleId,
        CancellationToken cancellationToken
    )
    {
        RemoveRolePermanentlyByRoleIdRequest featureRequest = new() { RoleId = roleId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.RemoveRolePermanentlyByRoleId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Restore a temporarily removed role by input role id.
    /// </summary>
    /// <param name="roleId">
    ///     Id of role to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Role/remove/{roleId:guid}
    ///
    /// </remarks>
    [HttpPatch(template: "remove/{roleId:guid}")]
    public async Task<IActionResult> RestoreByIdAsync(
        [FromRoute] [Required] Guid roleId,
        CancellationToken cancellationToken
    )
    {
        // Restore role by role id.
        RestoreRoleByRoleIdRequest featureRequest = new() { RoleId = roleId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Role.RestoreRoleByRoleId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }
}
