using System;
using System.Collections.Generic;
using FuDever.Application.Features.Position.CreatePosition;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Position.CreatePosition.Others;

/// <summary>
///     Http response manager for create position feature.
/// </summary>
internal sealed class CreatePositionHttpResponseManager
{
    private readonly Dictionary<
        CreatePositionResponseStatusCode,
        Func<CreatePositionRequest, CreatePositionResponse, CreatePositionHttpResponse>
    > _dictionary;

    internal CreatePositionHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.POSITION_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PositionIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.POSITION_ALREADY_EXISTS,
            value: (request, response) =>
                new PositionAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePositionResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        CreatePositionRequest,
        CreatePositionResponse,
        CreatePositionHttpResponse
    > Resolve(CreatePositionResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
