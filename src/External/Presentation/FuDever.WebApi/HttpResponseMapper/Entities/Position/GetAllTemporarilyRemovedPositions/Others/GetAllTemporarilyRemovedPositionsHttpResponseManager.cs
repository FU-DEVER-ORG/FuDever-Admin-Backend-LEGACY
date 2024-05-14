using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllTemporarilyRemovedPositions.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed positions feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedPositionsHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedPositionsResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedPositionsRequest,
            GetAllTemporarilyRemovedPositionsResponse,
            GetAllTemporarilyRemovedPositionsHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedPositionsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPositionsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPositionsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPositionsResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedPositionsResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedPositionsRequest,
        GetAllTemporarilyRemovedPositionsResponse,
        GetAllTemporarilyRemovedPositionsHttpResponse
    > Resolve(GetAllTemporarilyRemovedPositionsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
