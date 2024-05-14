using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.UpdatePositionByPositionId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.UpdatePositionByPositionId.Others;

/// <summary>
///     Http response manager for update position
///     by position id feature.
/// </summary>
internal sealed class UpdatePositionByPositionIdHttpResponseManager
{
    private readonly Dictionary<
        UpdatePositionByPositionIdResponseStatusCode,
        Func<
            UpdatePositionByPositionIdRequest,
            UpdatePositionByPositionIdResponse,
            UpdatePositionByPositionIdHttpResponse
        >
    > _dictionary;

    internal UpdatePositionByPositionIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.POSITION_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PositionIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.POSITION_ALREADY_EXISTS,
            value: (request, response) =>
                new PositionAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND,
            value: (request, response) =>
                new PositionIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePositionByPositionIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdatePositionByPositionIdRequest,
        UpdatePositionByPositionIdResponse,
        UpdatePositionByPositionIdHttpResponse
    > Resolve(UpdatePositionByPositionIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
