using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionTemporarilyByPositionId.Others;

/// <summary>
///     Http response manager for remove position
///     temporarily by position id feature.
/// </summary>
internal sealed class RemovePositionTemporarilyByPositionIdHttpResponseManager
{
    private readonly Dictionary<
        RemovePositionTemporarilyByPositionIdResponseStatusCode,
        Func<
            RemovePositionTemporarilyByPositionIdRequest,
            RemovePositionTemporarilyByPositionIdResponse,
            RemovePositionTemporarilyByPositionIdHttpResponse
        >
    > _dictionary;

    internal RemovePositionTemporarilyByPositionIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND,
            value: (request, response) =>
                new PositionIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.POSITION_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PositionIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionTemporarilyByPositionIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemovePositionTemporarilyByPositionIdRequest,
        RemovePositionTemporarilyByPositionIdResponse,
        RemovePositionTemporarilyByPositionIdHttpResponse
    > Resolve(RemovePositionTemporarilyByPositionIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
