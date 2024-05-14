using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.RemoveSkillTemporarilyBySkillId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillTemporarilyBySkillId.Others;

/// <summary>
///     Http response manager for remove skill
///     temporarily by skill id feature.
/// </summary>
internal sealed class RemoveSkillTemporarilyBySkillIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveSkillTemporarilyBySkillIdResponseStatusCode,
        Func<
            RemoveSkillTemporarilyBySkillIdRequest,
            RemoveSkillTemporarilyBySkillIdResponse,
            RemoveSkillTemporarilyBySkillIdHttpResponse
        >
    > _dictionary;

    internal RemoveSkillTemporarilyBySkillIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND,
            value: (request, response) =>
                new SkillIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.SKILL_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new SkillIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillTemporarilyBySkillIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveSkillTemporarilyBySkillIdRequest,
        RemoveSkillTemporarilyBySkillIdResponse,
        RemoveSkillTemporarilyBySkillIdHttpResponse
    > Resolve(RemoveSkillTemporarilyBySkillIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
