using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.RemovePlatformPermanentlyByPlatformId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RemovePlatformPermanentlyByPlatformId.Others;

/// <summary>
///     Http response manager for remove platform
///     permanently by platform id feature.
/// </summary>
internal sealed class RemovePlatformPermanentlyByPlatformIdHttpResponseManager
{
    private readonly Dictionary<
        RemovePlatformPermanentlyByPlatformIdResponseStatusCode,
        Func<
            RemovePlatformPermanentlyByPlatformIdRequest,
            RemovePlatformPermanentlyByPlatformIdResponse,
            RemovePlatformPermanentlyByPlatformIdHttpResponse
        >
    > _dictionary;

    internal RemovePlatformPermanentlyByPlatformIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND,
            value: (request, response) =>
                new PlatformIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PlatformIsNotTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemovePlatformPermanentlyByPlatformIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemovePlatformPermanentlyByPlatformIdRequest,
        RemovePlatformPermanentlyByPlatformIdResponse,
        RemovePlatformPermanentlyByPlatformIdHttpResponse
    > Resolve(RemovePlatformPermanentlyByPlatformIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
