using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.ConfirmUserRegistrationConfirmedEmail;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ConfirmUserRegistrationConfirmedEmail.Others;

/// <summary>
///     Http response manager for confirm user registration confirmed email.
/// </summary>
internal sealed class ConfirmUserRegistrationConfirmedEmailHttpResponseManager
{
    private readonly Dictionary<
        ConfirmUserRegistrationConfirmedEmailResponseStatusCode,
        Func<
            ConfirmUserRegistrationConfirmedEmailRequest,
            ConfirmUserRegistrationConfirmedEmailResponse,
            ConfirmUserRegistrationConfirmedEmailHttpResponse
        >
    > _dictionary;

    internal ConfirmUserRegistrationConfirmedEmailHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.TOKEN_IS_NOT_IN_CORRECT_FORMAT,
            value: (_, response) => new TokenIsNotInCorrectFormatHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_NOT_FOUND,
            value: (_, response) => new UserIsNotFoundHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.USER_HAS_CONFIRMED_REGISTRATION_EMAIL,
            value: (_, response) =>
                new UserHasConfirmedRegistrationEmailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ConfirmUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (_, response) => new UserIsTemporarilyRemovedHttpResponse(response: response)
        );
    }

    internal Func<
        ConfirmUserRegistrationConfirmedEmailRequest,
        ConfirmUserRegistrationConfirmedEmailResponse,
        ConfirmUserRegistrationConfirmedEmailHttpResponse
    > Resolve(ConfirmUserRegistrationConfirmedEmailResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
