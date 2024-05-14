using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.UpdateSkillBySkillId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.UpdateSkillBySkillId.Others;

/// <summary>
///     Http response manager for update skill
///     by skill id feature.
/// </summary>
internal sealed class UpdateSkillBySkillIdHttpResponseManager
{
    private readonly Dictionary<
        UpdateSkillBySkillIdResponseStatusCode,
        Func<
            UpdateSkillBySkillIdRequest,
            UpdateSkillBySkillIdResponse,
            UpdateSkillBySkillIdHttpResponse
        >
    > _dictionary;

    internal UpdateSkillBySkillIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.SKILL_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new SkillIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.SKILL_ALREADY_EXISTS,
            value: (request, response) =>
                new SkillAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND,
            value: (request, response) =>
                new SkillIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateSkillBySkillIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdateSkillBySkillIdRequest,
        UpdateSkillBySkillIdResponse,
        UpdateSkillBySkillIdHttpResponse
    > Resolve(UpdateSkillBySkillIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
