using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.GetAllHobbiesByHobbyName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbiesByHobbyName.Others;

/// <summary>
///     Http response manager for get all hobbies
///     by hobby name feature.
/// </summary>
internal sealed class GetAllHobbiesByHobbyNameHttpResponseManager
{
    private readonly Dictionary<
        GetAllHobbiesByHobbyNameResponseStatusCode,
        Func<
            GetAllHobbiesByHobbyNameRequest,
            GetAllHobbiesByHobbyNameResponse,
            GetAllHobbiesByHobbyNameHttpResponse
        >
    > _dictionary;

    internal GetAllHobbiesByHobbyNameHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllHobbiesByHobbyNameResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllHobbiesByHobbyNameResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllHobbiesByHobbyNameRequest,
        GetAllHobbiesByHobbyNameResponse,
        GetAllHobbiesByHobbyNameHttpResponse
    > Resolve(GetAllHobbiesByHobbyNameResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
