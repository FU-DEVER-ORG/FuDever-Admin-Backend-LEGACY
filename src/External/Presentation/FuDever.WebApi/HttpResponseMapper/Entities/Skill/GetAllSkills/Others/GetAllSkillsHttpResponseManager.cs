using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.GetAllSkills;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkills.Others;

/// <summary>
///     Http response manager for get all skills feature.
/// </summary>
internal sealed class GetAllSkillsHttpResponseManager
{
    private readonly Dictionary<
        GetAllSkillsResponseStatusCode,
        Func<GetAllSkillsRequest, GetAllSkillsResponse, GetAllSkillsHttpResponse>
    > _dictionary;

    internal GetAllSkillsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllSkillsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllSkillsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<GetAllSkillsRequest, GetAllSkillsResponse, GetAllSkillsHttpResponse> Resolve(
        GetAllSkillsResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
