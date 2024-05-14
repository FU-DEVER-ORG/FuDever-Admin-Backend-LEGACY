using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.GetAllTemporarilyRemovedHobbies;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.GetAllTemporarilyRemovedHobbies.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed hobbies feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedHobbiesHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedHobbiesResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedHobbiesRequest,
            GetAllTemporarilyRemovedHobbiesResponse,
            GetAllTemporarilyRemovedHobbiesHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedHobbiesHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedHobbiesResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedHobbiesResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedHobbiesResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedHobbiesResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedHobbiesRequest,
        GetAllTemporarilyRemovedHobbiesResponse,
        GetAllTemporarilyRemovedHobbiesHttpResponse
    > Resolve(GetAllTemporarilyRemovedHobbiesResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
