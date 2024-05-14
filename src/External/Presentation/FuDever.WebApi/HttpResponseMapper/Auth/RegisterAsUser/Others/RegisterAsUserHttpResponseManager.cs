using System;
using System.Collections.Generic;
using FuDever.Application.Features.Auth.RegisterAsUser;

namespace FuDever.WebApi.HttpResponseMapper.Auth.RegisterAsUser.Others;

/// <summary>
///     Http response manager for register as user feature.
/// </summary>
internal sealed class RegisterAsUserHttpResponseManager
{
    private readonly Dictionary<
        RegisterAsUserResponseStatusCode,
        Func<RegisterAsUserRequest, RegisterAsUserResponse, RegisterAsUserHttpResponse>
    > _dictionary;

    internal RegisterAsUserHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RegisterAsUserResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RegisterAsUserResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RegisterAsUserResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        //_dictionary.Add(
        //    key: RegisterAsUserResponseStatusCode.USERNAME_IS_NOT_A_REAL_EMAIL,
        //    value: (request, response) => new UsernameIsNotARealEmailHttpResponse(
        //        request: request,
        //        response: response));

        _dictionary.Add(
            key: RegisterAsUserResponseStatusCode.USER_PASSWORD_IS_NOT_VALID,
            value: (_, response) => new UserPasswordIsNotValidHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RegisterAsUserResponseStatusCode.USER_IS_EXISTED,
            value: (request, response) =>
                new UserIsExistedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RegisterAsUserResponseStatusCode.SENDING_USER_CONFIRMATION_MAIL_FAIL,
            value: (_, response) =>
                new SendingUserConfirmationMailFailHttpResponse(response: response)
        );
    }

    internal Func<
        RegisterAsUserRequest,
        RegisterAsUserResponse,
        RegisterAsUserHttpResponse
    > Resolve(RegisterAsUserResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
