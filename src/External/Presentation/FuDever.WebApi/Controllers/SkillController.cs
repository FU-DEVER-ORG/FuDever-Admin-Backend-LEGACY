using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using FuDever.Application.Features.Skill.CreateSkill;
using FuDever.Application.Features.Skill.GetAllSkills;
using FuDever.Application.Features.Skill.GetAllSkillsBySkillName;
using FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;
using FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;
using FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;
using FuDever.Application.Features.Skill.RestoreSkillBySkillId;
using FuDever.Application.Features.Skill.UpdateSkillBySkillId;
using FuDever.WebApi.DTOs.Skill.Incomings;
using FuDever.WebApi.HttpResponseMapper.Others;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuDever.WebApi.Controllers;

[Consumes(contentType: MediaTypeNames.Application.Json)]
[Produces(contentType: MediaTypeNames.Application.Json)]
[ApiController]
[Route(template: "api/[controller]")]
public sealed class SkillController : ControllerBase
{
    private readonly ISender _sender;
    private readonly HttpResponseMapperManager _httpResponseMapperManager;

    public SkillController(ISender sender, HttpResponseMapperManager httpResponseMapperManager)
    {
        _sender = sender;
        _httpResponseMapperManager = httpResponseMapperManager;
    }

    /// <summary>
    ///     Get all skills which are not temporarily removed.
    /// </summary>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of skills.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Skill/all
    ///
    /// </remarks>
    [HttpGet(template: "all")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        // Get all skills which are not temporarily removed.
        GetAllSkillsRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.GetAllSkills.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all skills having name equal to
    ///     input <paramref name="skillName"/> in lowercase.
    /// </summary>
    /// <param name="skillName">
    ///     Use to search for skills with similar name.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <returns>
    ///     List of skills having name equal to
    ///     input <paramref name="skillName"/>.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Skill?name={skillName}
    ///
    /// </remarks>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllByNameAsync(
        [FromQuery(Name = "name")] [Required] string skillName,
        CancellationToken cancellationToken
    )
    {
        skillName = skillName.Trim();

        // Find skill by name.
        GetAllSkillsBySkillNameRequest featureRequest =
            new() { SkillName = skillName, CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.GetAllSkillsBySkillName.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Create new skill with credentials
    ///     from input <paramref name="dto"/>.
    /// </summary>
    /// <param name="dto">
    ///     Containing credentials that are
    ///     used to create a new skill.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST api/Skill
    ///     {
    ///         "skillName": "string"
    ///     }
    ///
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateSkillDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Create skill
        CreateSkillRequest featureRequest = new() { NewSkillName = dto.SkillName };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.CreateSkill.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        if (apiResponse.HttpCode == StatusCodes.Status201Created)
        {
            return Created(
                uri: $"{HttpContext.Request.Path}?name={dto.SkillName}",
                value: apiResponse
            );
        }

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///    Temporarily remove an existed skill
    ///    by input <paramref name="skillId"/>.
    /// </summary>
    /// <param name="skillId">
    ///     Id of skill to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     A token that is used to notify the system
    ///     to cancel the current operation when user stop
    ///     the request.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Skill/{skillId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "{skillId:guid}")]
    public async Task<IActionResult> RemoveTemporarilyByIdAsync(
        [FromRoute] [Required] Guid skillId,
        CancellationToken cancellationToken
    )
    {
        // Remove skill temporarily by skill id.
        RemoveSkillTemporarilyBySkillIdRequest featureRequest = new() { SkillId = skillId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.RemoveSkillTemporarilyBySkillId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Update an existed skill with credentials.
    /// </summary>
    /// <param name="skillId">
    ///     Id of skill to search for.
    /// </param>
    /// <param name="dto">
    ///     Containing credentials that are used to change the found skill.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Skill/{skillId:guid}
    ///     {
    ///         "newSkillName" : "string"
    ///     }
    ///
    /// </remarks>
    [HttpPatch(template: "{skillId:guid}")]
    public async Task<IActionResult> UpdateByIdAsync(
        [FromRoute] [Required] Guid skillId,
        [FromBody] UpdateSkillDto dto,
        CancellationToken cancellationToken
    )
    {
        dto.NormalizeAllProperties();

        // Update skill by skill id.
        UpdateSkillBySkillIdRequest featureRequest =
            new() { NewSkillName = dto.NewSkillName, SkillId = skillId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.UpdateSkillBySkillId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Get all skills that have been temporarily removed.
    /// </summary>
    /// <returns>
    ///     A list of temporarily removed skills.
    /// </returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET api/Skill/remove/all
    ///
    /// </remarks>
    [HttpGet(template: "remove/all")]
    public async Task<IActionResult> GetAllTemporarilyRemovedAsync(
        CancellationToken cancellationToken
    )
    {
        // Get all temporarily removed skills.
        GetAllTemporarilyRemovedSkillsRequest featureRequest = new() { CacheExpiredTime = 60 };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.GetAllTemporarilyRemovedSkills.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Permanently remove an existed temporarily removed skill.
    ///     by input skill id.
    /// </summary>
    /// <param name="skillId">
    ///     Id of skill to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE api/Skill/remove/{skillId:guid}
    ///
    /// </remarks>
    [HttpDelete(template: "remove/{skillId:guid}")]
    public async Task<IActionResult> RemovePermanentlyByIdAsync(
        [FromRoute] [Required] Guid skillId,
        CancellationToken cancellationToken
    )
    {
        RemoveSkillPermanentlyBySkillIdRequest featureRequest = new() { SkillId = skillId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.RemoveSkillPermanentlyBySkillId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }

    /// <summary>
    ///     Restore a temporarily removed skill by input skill id.
    /// </summary>
    /// <param name="skillId">
    ///     Id of skill to search for.
    /// </param>
    /// <param name="cancellationToken">
    ///     Automatic initialized token for aborting current operation.
    /// </param>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH api/Skill/remove/{skillId:guid}
    ///
    /// </remarks>
    [HttpPatch(template: "remove/{skillId:guid}")]
    public async Task<IActionResult> RestoreByIdAsync(
        [FromRoute] [Required] Guid skillId,
        CancellationToken cancellationToken
    )
    {
        // Restore skill by skill id.
        RestoreSkillBySkillIdRequest featureRequest = new() { SkillId = skillId };

        var featureResponse = await _sender.Send(
            request: featureRequest,
            cancellationToken: cancellationToken
        );

        var apiResponse = _httpResponseMapperManager
            .Skill.RestoreSkillBySkillId.Resolve(statusCode: featureResponse.StatusCode)
            .Invoke(arg1: featureRequest, arg2: featureResponse);

        return StatusCode(statusCode: apiResponse.HttpCode, value: apiResponse);
    }
}
