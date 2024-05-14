using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.GetAllTemporarilyRemovedPlatforms;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllTemporarilyRemovedPlatforms.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed platforms feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedPlatformsHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedPlatformsResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedPlatformsRequest,
            GetAllTemporarilyRemovedPlatformsResponse,
            GetAllTemporarilyRemovedPlatformsHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedPlatformsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPlatformsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPlatformsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPlatformsResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPlatformsResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedPlatformsRequest,
        GetAllTemporarilyRemovedPlatformsResponse,
        GetAllTemporarilyRemovedPlatformsHttpResponse
    > Resolve(GetAllTemporarilyRemovedPlatformsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
