using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.RemovePositionPermanentlyByPositionId.Others;

/// <summary>
///     Http response manager for remove position
///     permanently by position id feature.
/// </summary>
internal sealed class RemovePositionPermanentlyByPositionIdHttpResponseManager
{
    private readonly Dictionary<
        RemovePositionPermanentlyByPositionIdResponseStatusCode,
        Func<
            RemovePositionPermanentlyByPositionIdRequest,
            RemovePositionPermanentlyByPositionIdResponse,
            RemovePositionPermanentlyByPositionIdHttpResponse
        >
    > _dictionary;

    internal RemovePositionPermanentlyByPositionIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.POSITION_IS_NOT_FOUND,
            value: (request, response) =>
                new PositionIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.POSITION_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PositionIsNotTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePositionPermanentlyByPositionIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemovePositionPermanentlyByPositionIdRequest,
        RemovePositionPermanentlyByPositionIdResponse,
        RemovePositionPermanentlyByPositionIdHttpResponse
    > Resolve(RemovePositionPermanentlyByPositionIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
