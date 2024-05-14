using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.RemovePlatformTemporarilyByPlatformId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformTemporarilyByPlatformId.Others;

/// <summary>
///     Http response manager for remove platform
///     temporarily by platform id feature.
/// </summary>
internal sealed class RemovePlatformTemporarilyByPlatformIdHttpResponseManager
{
    private readonly Dictionary<
        RemovePlatformTemporarilyByPlatformIdResponseStatusCode,
        Func<
            RemovePlatformTemporarilyByPlatformIdRequest,
            RemovePlatformTemporarilyByPlatformIdResponse,
            RemovePlatformTemporarilyByPlatformIdHttpResponse
        >
    > _dictionary;

    internal RemovePlatformTemporarilyByPlatformIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND,
            value: (request, response) =>
                new PlatformIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.PLATFORM_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PlatformIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformTemporarilyByPlatformIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemovePlatformTemporarilyByPlatformIdRequest,
        RemovePlatformTemporarilyByPlatformIdResponse,
        RemovePlatformTemporarilyByPlatformIdHttpResponse
    > Resolve(RemovePlatformTemporarilyByPlatformIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
