﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Hobby.CreateHobby;
using FuDever.Application.Features.Hobby.GetAllHobbies;
using FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;
using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;
using FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;
using FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;
using FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;
using FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;
using FuDever.WebApi.DTOs.Hobby.Incomings;
using FuDever.WebApi.HttpResponseMapper.Others;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.Controllers;

[Consumes(contentType: MediaTypeNames.Application.Json)]
[Produces(contentType: MediaTypeNames.Application.Json)]
[ApiController]
[Route(template: "api/[controller]")]
public sealed class HobbyController : ControllerBase
{
    private readonly ISender _sender;
    private readonly HttpResponseMapperManager _httpResponseMapperManager;

    public HobbyController(ISender sender, HttpResponseMapperManager httpResponseMapperManager)
    {
        _sender = sender;
        _httpResponseMapperManager = httpResponseMapperManager;
    }

    /// <summary>
    ///     Get all hobbies which are not temporarily removed.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of hobbies.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Hobby/all
    ///
    /// </remarks>
    [HttpGet(template: "all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        // Get all hobbies which are not temporarily removed.
        GetAllHobbiesRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.GetAllHobbies.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all hobbies having name equal to
    ///     input <paramref name="hobbyName"/> in lowercase.
    /// </summary>
    /// <param name="hobbyName">
    ///     Use to search for hobbies with similar name.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of hobbies having name equal to
    ///     input <paramref name="hobbyName"/>.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Hobby?name={hobbyName}
    ///
    /// </remarks>
    [HttpGet]
    public async Task<IActionResult> GetAllByNameAsync(
        [FromQuery(Name = "name")] [Required] string hobbyName,
        CancellationToken cancellationToken
    )
    {
        hobbyName = hobbyName.Trim();

        // Find hobby by name.
        GetAllHobbiesByHobbyNameRequest featureRequest =
            new() { HobbyName = hobbyName, CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.GetAllHobbiesByHobbyName.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Create new hobby with credentials
    ///     from input <paramref name="dto"/>.
    /// </summary>
    /// <param name="dto">
    ///     Containing credentials that are
    ///     used to create a new hobby.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Hobby
    ///     {
    ///         "hobbyName": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateHobbyDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Create hobby
        CreateHobbyRequest featureRequest = new() { NewHobbyName = dto.HobbyName };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.CreateHobby.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        if (apiResponse.HttpCode == StatusCodes.Status201Created)
        {
            return Created(
                uri: $"{HttpContext.Request.Path}?name={dto.HobbyName}",
                value: apiResponse
            );
        }

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///    Temporarily remove an existed hobby
    ///    by input <paramref name="hobbyId"/>.
    /// </summary>
    /// <param name="hobbyId">
    ///     Id of hobby to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Hobby/{hobbyId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "{hobbyId:guid}")]
    public async Task<IActionResult> RemoveTemporarilyByIdAsync(
        [FromRoute] [Required] Guid hobbyId,
        CancellationToken cancellationToken
    )
    {
        // Remove hobby temporarily by hobby id.
        RemoveHobbyTemporarilyByHobbyIdRequest featureRequest = new() { HobbyId = hobbyId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.RemoveHobbyTemporarilyByHobbyId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Update an existed hobby with credentials.
    /// </summary>
    /// <param name="hobbyId">
    ///     Id of hobby to search for.
    /// </param>
    /// <param name="dto">
    ///     Containing credentials that are used to change the found hobby.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Hobby/{hobbyId:guid}
    ///     {
    ///         "newHobbyName" : "string"
    ///     }
    ///
    /// </remarks>
    [HttpPatch(template: "{hobbyId:guid}")]
    public async Task<IActionResult> UpdateByIdAsync(
        [FromRoute] [Required] Guid hobbyId,
        [FromBody] UpdateHobbyDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Update hobby by hobby id.
        UpdateHobbyByHobbyIdRequest featureRequest =
            new() { NewHobbyName = dto.NewHobbyName, HobbyId = hobbyId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.UpdateHobbyByHobbyId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all hobbies that have been temporarily removed.
    /// </summary>
    /// <returns>
    ///     A list of temporarily removed hobbies.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Hobby/remove/all
    ///
    /// </remarks>
    [HttpGet(template: "remove/all")]
    public async Task<IActionResult> GetAllTemporarilyRemovedAsync(
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed hobbies.
        GetAllTemporarilyRemovedHobbiesRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.GetAllTemporarilyRemovedHobbies.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Permanently remove an existed temporarily removed hobby.
    ///     by input hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Id of hobby to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Hobby/remove/{hobbyId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "remove/{hobbyId:guid}")]
    public async Task<IActionResult> RemovePermanentlyByIdAsync(
        [FromRoute] [Required] Guid hobbyId,
        CancellationToken cancellationToken
    )
    {
        RemoveHobbyPermanentlyByHobbyIdRequest featureRequest = new() { HobbyId = hobbyId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.RemoveHobbyPermanentlyByHobbyId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Restore a temporarily removed hobby by input hobby id.
    /// </summary>
    /// <param name="hobbyId">
    ///     Id of hobby to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Hobby/remove/{hobbyId:guid}
    ///
    /// </remarks>
    [HttpPatch(template: "remove/{hobbyId:guid}")]
    public async Task<IActionResult> RestoreByIdAsync(
        [FromRoute] [Required] Guid hobbyId,
        CancellationToken cancellationToken
    )
    {
        // Restore hobby by hobby id.
        RestoreHobbyByHobbyIdRequest featureRequest = new() { HobbyId = hobbyId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Hobby.RestoreHobbyByHobbyId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }
}
