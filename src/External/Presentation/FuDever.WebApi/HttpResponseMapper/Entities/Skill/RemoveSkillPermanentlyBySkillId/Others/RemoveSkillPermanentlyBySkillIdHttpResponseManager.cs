using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.RemoveSkillPermanentlyBySkillId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.RemoveSkillPermanentlyBySkillId.Others;

/// <summary>
///     Http response manager for remove skill
///     permanently by skill id feature.
/// </summary>
internal sealed class RemoveSkillPermanentlyBySkillIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveSkillPermanentlyBySkillIdResponseStatusCode,
        Func<
            RemoveSkillPermanentlyBySkillIdRequest,
            RemoveSkillPermanentlyBySkillIdResponse,
            RemoveSkillPermanentlyBySkillIdHttpResponse
        >
    > _dictionary;

    internal RemoveSkillPermanentlyBySkillIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.SKILL_IS_NOT_FOUND,
            value: (request, response) =>
                new SkillIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.SKILL_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new SkillIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveSkillPermanentlyBySkillIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveSkillPermanentlyBySkillIdRequest,
        RemoveSkillPermanentlyBySkillIdResponse,
        RemoveSkillPermanentlyBySkillIdHttpResponse
    > Resolve(RemoveSkillPermanentlyBySkillIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
