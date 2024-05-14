using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.CreatePlatform;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.CreatePlatform.Others;

/// <summary>
///     Http response manager for create platform feature.
/// </summary>
internal sealed class CreatePlatformHttpResponseManager
{
    private readonly Dictionary<
        CreatePlatformResponseStatusCode,
        Func<CreatePlatformRequest, CreatePlatformResponse, CreatePlatformHttpResponse>
    > _dictionary;

    internal CreatePlatformHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.PLATFORM_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PlatformIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.PLATFORM_ALREADY_EXISTS,
            value: (request, response) =>
                new PlatformAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreatePlatformResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        CreatePlatformRequest,
        CreatePlatformResponse,
        CreatePlatformHttpResponse
    > Resolve(CreatePlatformResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
