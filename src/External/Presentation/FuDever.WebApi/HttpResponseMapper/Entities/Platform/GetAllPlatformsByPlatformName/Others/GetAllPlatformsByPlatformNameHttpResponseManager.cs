using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.GetAllPlatformsByPlatformName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatformsByPlatformName.Others;

/// <summary>
///     Http response manager for get all platforms
///     by platform name feature.
/// </summary>
internal sealed class GetAllPlatformsByPlatformNameHttpResponseManager
{
    private readonly Dictionary<
        GetAllPlatformsByPlatformNameResponseStatusCode,
        Func<
            GetAllPlatformsByPlatformNameRequest,
            GetAllPlatformsByPlatformNameResponse,
            GetAllPlatformsByPlatformNameHttpResponse
        >
    > _dictionary;

    internal GetAllPlatformsByPlatformNameHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllPlatformsByPlatformNameResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllPlatformsByPlatformNameResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllPlatformsByPlatformNameRequest,
        GetAllPlatformsByPlatformNameResponse,
        GetAllPlatformsByPlatformNameHttpResponse
    > Resolve(GetAllPlatformsByPlatformNameResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
