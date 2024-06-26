using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.Login;

namespace FuDever.WebApi.HttpResponseMapper.Auth.Login.Others;

/// <summary>
///     Http response manager for login feature.
/// </summary>
internal sealed class LoginHttpResponseManager
{
    private readonly Dictionary<
        LoginResponseStatusCode,
        Func<LoginRequest, LoginResponse, LoginHttpResponse>
    > _dictionary;

    internal LoginHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: LoginResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_EMAIL_IS_NOT_CONFIRMED,
            value: (request, response) =>
                new UserEmailIsNotConfirmedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_IS_LOCKED_OUT,
            value: (request, response) =>
                new UserIsLockedOutHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_IS_STILL_PENDING,
            value: (request, response) =>
                new UserIsStillPendingHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_PASSWORD_IS_NOT_CORRECT,
            value: (_, response) => new UserPasswordIsNotCorrectHttpResponse(response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_IS_NOT_FOUND,
            value: (request, response) =>
                new UserIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new UserIsTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_IS_ALREADY_REJECTED,
            value: (request, response) =>
                new UserIsAlreadyRejectedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: LoginResponseStatusCode.USER_IS_ALREADY_EXPIRED,
            value: (request, response) =>
                new UserIsAlreadyExpiredHttpResponse(request: request, response: response)
        );
    }

    internal Func<LoginRequest, LoginResponse, LoginHttpResponse> Resolve(
        LoginResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
