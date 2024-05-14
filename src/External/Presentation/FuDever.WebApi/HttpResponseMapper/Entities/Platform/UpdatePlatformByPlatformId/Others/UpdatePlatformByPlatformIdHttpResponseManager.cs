using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.UpdatePlatformByPlatformId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.UpdatePlatformByPlatformId.Others;

/// <summary>
///     Http response manager for update platform
///     by platform id feature.
/// </summary>
internal sealed class UpdatePlatformByPlatformIdHttpResponseManager
{
    private readonly Dictionary<
        UpdatePlatformByPlatformIdResponseStatusCode,
        Func<
            UpdatePlatformByPlatformIdRequest,
            UpdatePlatformByPlatformIdResponse,
            UpdatePlatformByPlatformIdHttpResponse
        >
    > _dictionary;

    internal UpdatePlatformByPlatformIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new PlatformIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.PLATFORM_ALREADY_EXISTS,
            value: (request, response) =>
                new PlatformAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.PLATFORM_IS_NOT_FOUND,
            value: (request, response) =>
                new PlatformIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdatePlatformByPlatformIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdatePlatformByPlatformIdRequest,
        UpdatePlatformByPlatformIdResponse,
        UpdatePlatformByPlatformIdHttpResponse
    > Resolve(UpdatePlatformByPlatformIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
