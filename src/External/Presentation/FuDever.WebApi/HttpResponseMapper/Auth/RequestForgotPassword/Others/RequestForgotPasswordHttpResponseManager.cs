using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.RequestForgotPassword;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RequestForgotPassword.Others;

/// <summary>
///     Http response manager for request forgot password feature.
/// </summary>
internal sealed class RequestForgotPasswordHttpResponseManager
{
    private readonly Dictionary<
        RequestForgotPasswordResponseStatusCode,
        Func<
            RequestForgotPasswordRequest,
            RequestForgotPasswordResponse,
            RequestForgotPasswordHttpResponse
        >
    > _dictionary;

    internal RequestForgotPasswordHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RequestForgotPasswordResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RequestForgotPasswordResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RequestForgotPasswordResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RequestForgotPasswordResponseStatusCode.USER_IS_NOT_FOUND,
            value: (request, response) =>
                new UserIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RequestForgotPasswordResponseStatusCode.SENDING_USER_RESET_PASSWORD_MAIL_FAIL,
            value: (_, response) =>
                new SendingUserResetPasswordMailFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RequestForgotPasswordResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (_, response) => new UserIsTemporarilyRemovedHttpResponse(response: response)
        );
    }

    internal Func<
        RequestForgotPasswordRequest,
        RequestForgotPasswordResponse,
        RequestForgotPasswordHttpResponse
    > Resolve(RequestForgotPasswordResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
