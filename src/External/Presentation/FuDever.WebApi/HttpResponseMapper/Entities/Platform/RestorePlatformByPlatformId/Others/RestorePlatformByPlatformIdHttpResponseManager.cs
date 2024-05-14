using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.RestorePlatformByPlatformId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.RestorePlatformByPlatformId.Others;

/// <summary>
///     Http response manager for restore platform
///     by platform id feature.
/// </summary>
internal sealed class RestorePlatformByPlatformIdHttpResponseManager
{
    private readonly Dictionary<
        RestorePlatformByPlatformIdResponseStatusCode,
        Func<
            RestorePlatformByPlatformIdRequest,
            RestorePlatformByPlatformIdResponse,
            RestorePlatformByPlatformIdHttpResponse
        >
    > _dictionary;

    internal RestorePlatformByPlatformIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND,
            value: (request, response) =>
                new PlatformIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PlatformIsNotTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestorePlatformByPlatformIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestorePlatformByPlatformIdRequest,
        RestorePlatformByPlatformIdResponse,
        RestorePlatformByPlatformIdHttpResponse
    > Resolve(RestorePlatformByPlatformIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
