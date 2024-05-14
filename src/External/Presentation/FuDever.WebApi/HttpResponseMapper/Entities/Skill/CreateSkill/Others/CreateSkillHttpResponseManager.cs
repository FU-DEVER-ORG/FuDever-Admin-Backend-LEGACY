using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.CreateSkill;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.CreateSkill.Others;

/// <summary>
///     Http response manager for create skill feature.
/// </summary>
internal sealed class CreateSkillHttpResponseManager
{
    private readonly Dictionary<
        CreateSkillResponseStatusCode,
        Func<CreateSkillRequest, CreateSkillResponse, CreateSkillHttpResponse>
    > _dictionary;

    internal CreateSkillHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.SKILL_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new SkillIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.SKILL_ALREADY_EXISTS,
            value: (request, response) =>
                new SkillAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateSkillResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<CreateSkillRequest, CreateSkillResponse, CreateSkillHttpResponse> Resolve(
        CreateSkillResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
