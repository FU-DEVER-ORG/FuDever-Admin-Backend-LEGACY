using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.ChangingPassword;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ChangingPassword.Others;

/// <summary>
///     Http response manager for changing password feature.
/// </summary>
internal sealed class ChangingPasswordHttpResponseManager
{
    private readonly Dictionary<
        ChangingPasswordResponseStatusCode,
        Func<ChangingPasswordRequest, ChangingPasswordResponse, ChangingPasswordHttpResponse>
    > _dictionary;

    internal ChangingPasswordHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: ChangingPasswordResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ChangingPasswordResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ChangingPasswordResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ChangingPasswordResponseStatusCode.NEW_PASSWORD_IS_NOT_VALID,
            value: (_, response) => new NewPasswordIsNotValidHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ChangingPasswordResponseStatusCode.RESET_PASSWORD_TOKEN_IS_NOT_FOUND,
            value: (_, response) => new ResetPasswordTokenIsNotFoundHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ChangingPasswordResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (_, response) => new UserIsTemporarilyRemovedHttpResponse(response: response)
        );
    }

    internal Func<
        ChangingPasswordRequest,
        ChangingPasswordResponse,
        ChangingPasswordHttpResponse
    > Resolve(ChangingPasswordResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
