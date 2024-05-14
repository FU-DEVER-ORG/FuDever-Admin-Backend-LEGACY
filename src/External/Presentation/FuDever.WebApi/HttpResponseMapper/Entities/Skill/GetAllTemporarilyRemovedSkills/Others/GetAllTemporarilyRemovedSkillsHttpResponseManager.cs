using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.GetAllTemporarilyRemovedSkills;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllTemporarilyRemovedSkills.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed skills feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedSkillsHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedSkillsResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedSkillsRequest,
            GetAllTemporarilyRemovedSkillsResponse,
            GetAllTemporarilyRemovedSkillsHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedSkillsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedSkillsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedSkillsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedSkillsResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedSkillsResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedSkillsRequest,
        GetAllTemporarilyRemovedSkillsResponse,
        GetAllTemporarilyRemovedSkillsHttpResponse
    > Resolve(GetAllTemporarilyRemovedSkillsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
