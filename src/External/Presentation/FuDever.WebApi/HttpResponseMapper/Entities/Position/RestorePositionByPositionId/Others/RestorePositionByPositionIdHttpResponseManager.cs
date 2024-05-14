using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.RestorePositionByPositionId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RestorePositionByPositionId.Others;

/// <summary>
///     Http response manager for restore position
///     by position id feature.
/// </summary>
internal sealed class RestorePositionByPositionIdHttpResponseManager
{
    private readonly Dictionary<
        RestorePositionByPositionIdResponseStatusCode,
        Func<
            RestorePositionByPositionIdRequest,
            RestorePositionByPositionIdResponse,
            RestorePositionByPositionIdHttpResponse
        >
    > _dictionary;

    internal RestorePositionByPositionIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND,
            value: (request, response) =>
                new PositionIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.POSITION_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PositionIsNotTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePositionByPositionIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestorePositionByPositionIdRequest,
        RestorePositionByPositionIdResponse,
        RestorePositionByPositionIdHttpResponse
    > Resolve(RestorePositionByPositionIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
