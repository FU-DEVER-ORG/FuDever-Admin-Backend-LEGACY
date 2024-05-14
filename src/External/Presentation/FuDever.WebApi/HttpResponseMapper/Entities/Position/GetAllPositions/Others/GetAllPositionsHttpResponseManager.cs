using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.GetAllPositions;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositions.Others;

/// <summary>
///     Http response manager for get all positions feature.
/// </summary>
internal sealed class GetAllPositionsHttpResponseManager
{
    private readonly Dictionary<
        GetAllPositionsResponseStatusCode,
        Func<GetAllPositionsRequest, GetAllPositionsResponse, GetAllPositionsHttpResponse>
    > _dictionary;

    internal GetAllPositionsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllPositionsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllPositionsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllPositionsRequest,
        GetAllPositionsResponse,
        GetAllPositionsHttpResponse
    > Resolve(GetAllPositionsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
