using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.ResendUserRegistrationConfirmedEmail;

namespace FuDever.WebApi.HttpResponseMapper.Auth.ResendUserRegistrationConfirmedEmail.Others;

/// <summary>
///     Http response manager for resencd user registration confirmed email.
/// </summary>
internal sealed class ResendUserRegistrationConfirmedEmailHttpResponseManager
{
    private readonly Dictionary<
        ResendUserRegistrationConfirmedEmailResponseStatusCode,
        Func<
            ResendUserRegistrationConfirmedEmailRequest,
            ResendUserRegistrationConfirmedEmailResponse,
            ResendUserRegistrationConfirmedEmailHttpResponse
        >
    > _dictionary;

    internal ResendUserRegistrationConfirmedEmailHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: ResendUserRegistrationConfirmedEmailResponseStatusCode.SENDING_USER_CONFIRMATION_MAIL_FAIL,
            value: (_, response) =>
                new SendingUserConfirmationMailFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ResendUserRegistrationConfirmedEmailResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ResendUserRegistrationConfirmedEmailResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ResendUserRegistrationConfirmedEmailResponseStatusCode.USER_HAS_CONFIRMED_EMAIL,
            value: (_, response) =>
                new UserHasConfirmedRegistrationEmailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ResendUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_NOT_FOUND,
            value: (request, response) =>
                new UserIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: ResendUserRegistrationConfirmedEmailResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (_, response) => new UserIsTemporarilyRemovedHttpResponse(response: response)
        );
    }

    internal Func<
        ResendUserRegistrationConfirmedEmailRequest,
        ResendUserRegistrationConfirmedEmailResponse,
        ResendUserRegistrationConfirmedEmailHttpResponse
    > Resolve(ResendUserRegistrationConfirmedEmailResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
