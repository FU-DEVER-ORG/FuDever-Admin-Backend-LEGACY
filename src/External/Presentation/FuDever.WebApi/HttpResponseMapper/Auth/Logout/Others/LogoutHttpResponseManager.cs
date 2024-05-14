using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.Logout;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Logout.Others;

/// <summary>
///     Http response manager for logout feature.
/// </summary>
internal sealed class LogoutHttpResponseManager
{
    private readonly Dictionary<
        LogoutResponseStatusCode,
        Func<LogoutRequest, LogoutResponse, LogoutHttpResponse>
    > _dictionary;

    internal LogoutHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: LogoutResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LogoutResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LogoutResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LogoutResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<LogoutRequest, LogoutResponse, LogoutHttpResponse> Resolve(
        LogoutResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
