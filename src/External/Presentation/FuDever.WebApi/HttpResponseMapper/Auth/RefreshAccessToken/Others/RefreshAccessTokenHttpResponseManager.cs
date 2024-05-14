using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.RefreshAccessToken;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RefreshAccessToken.Others;

/// <summary>
///     Http response manager for refresh access token feature.
/// </summary>
internal sealed class RefreshAccessTokenHttpResponseManager
{
    private readonly Dictionary<
        RefreshAccessTokenResponseStatusCode,
        Func<RefreshAccessTokenRequest, RefreshAccessTokenResponse, RefreshAccessTokenHttpResponse>
    > _dictionary;

    internal RefreshAccessTokenHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.REFRESH_TOKEN_IS_EXPIRED,
            value: (_, response) => new RefreshTokenIsExpired(response: response)
        );

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.REFRESH_TOKEN_IS_NOT_FOUND,
            value: (_, response) => new RefreshTokenIsNotFound(response: response)
        );

        _dictionary.Add(
            key: RefreshAccessTokenResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RefreshAccessTokenRequest,
        RefreshAccessTokenResponse,
        RefreshAccessTokenHttpResponse
    > Resolve(RefreshAccessTokenResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
