using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.GetAllPositionsByPositionName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.GetAllPositionsByPositionName.Others;

/// <summary>
///     Http response manager for get all positions
///     by position name feature.
/// </summary>
internal sealed class GetAllPositionsByPositionNameHttpResponseManager
{
    private readonly Dictionary<
        GetAllPositionsByPositionNameResponseStatusCode,
        Func<
            GetAllPositionsByPositionNameRequest,
            GetAllPositionsByPositionNameResponse,
            GetAllPositionsByPositionNameHttpResponse
        >
    > _dictionary;

    internal GetAllPositionsByPositionNameHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllPositionsByPositionNameResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllPositionsByPositionNameResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllPositionsByPositionNameRequest,
        GetAllPositionsByPositionNameResponse,
        GetAllPositionsByPositionNameHttpResponse
    > Resolve(GetAllPositionsByPositionNameResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
