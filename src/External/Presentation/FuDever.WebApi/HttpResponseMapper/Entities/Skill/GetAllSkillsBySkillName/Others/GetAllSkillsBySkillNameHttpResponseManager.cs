using System;
using System.Collections.Generic;
using FuDever.Application.Features.Skill.GetAllSkillsBySkillName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Skill.GetAllSkillsBySkillName.Others;

/// <summary>
///     Http response manager for get all skills
///     by skill name feature.
/// </summary>
internal sealed class GetAllSkillsBySkillNameHttpResponseManager
{
    private readonly Dictionary<
        GetAllSkillsBySkillNameResponseStatusCode,
        Func<
            GetAllSkillsBySkillNameRequest,
            GetAllSkillsBySkillNameResponse,
            GetAllSkillsBySkillNameHttpResponse
        >
    > _dictionary;

    internal GetAllSkillsBySkillNameHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllSkillsBySkillNameResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllSkillsBySkillNameResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllSkillsBySkillNameRequest,
        GetAllSkillsBySkillNameResponse,
        GetAllSkillsBySkillNameHttpResponse
    > Resolve(GetAllSkillsBySkillNameResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
