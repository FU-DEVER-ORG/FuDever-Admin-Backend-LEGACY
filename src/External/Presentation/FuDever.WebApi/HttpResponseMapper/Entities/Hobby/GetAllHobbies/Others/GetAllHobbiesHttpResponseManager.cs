using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.GetAllHobbies;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllHobbies.Others;

/// <summary>
///     Http response manager for get all hobbies feature.
/// </summary>
internal sealed class GetAllHobbiesHttpResponseManager
{
    private readonly Dictionary<
        GetAllHobbiesResponseStatusCode,
        Func<GetAllHobbiesRequest, GetAllHobbiesResponse, GetAllHobbiesHttpResponse>
    > _dictionary;

    internal GetAllHobbiesHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllHobbiesResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllHobbiesResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<GetAllHobbiesRequest, GetAllHobbiesResponse, GetAllHobbiesHttpResponse> Resolve(
        GetAllHobbiesResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
