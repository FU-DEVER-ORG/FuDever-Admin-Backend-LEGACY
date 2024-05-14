using System;
using System.Collections.Generic;
using FuDever.Application.Features.Platform.GetAllPlatforms;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Platform.GetAllPlatforms.Others;

/// <summary>
///     Http response manager for get all platforms feature.
/// </summary>
internal sealed class GetAllPlatformsHttpResponseManager
{
    private readonly Dictionary<
        GetAllPlatformsResponseStatusCode,
        Func<GetAllPlatformsRequest, GetAllPlatformsResponse, GetAllPlatformsHttpResponse>
    > _dictionary;

    internal GetAllPlatformsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllPlatformsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllPlatformsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllPlatformsRequest,
        GetAllPlatformsResponse,
        GetAllPlatformsHttpResponse
    > Resolve(GetAllPlatformsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
