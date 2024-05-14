using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.RestoreSkillBySkillId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RestoreSkillBySkillId.Others;

/// <summary>
///     Http response manager for restore skill
///     by skill id feature.
/// </summary>
internal sealed class RestoreSkillBySkillIdHttpResponseManager
{
    private readonly Dictionary<
        RestoreSkillBySkillIdResponseStatusCode,
        Func<
            RestoreSkillBySkillIdRequest,
            RestoreSkillBySkillIdResponse,
            RestoreSkillBySkillIdHttpResponse
        >
    > _dictionary;

    internal RestoreSkillBySkillIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND,
            value: (request, response) =>
                new SkillIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.SKILL_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new SkillIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreSkillBySkillIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestoreSkillBySkillIdRequest,
        RestoreSkillBySkillIdResponse,
        RestoreSkillBySkillIdHttpResponse
    > Resolve(RestoreSkillBySkillIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
