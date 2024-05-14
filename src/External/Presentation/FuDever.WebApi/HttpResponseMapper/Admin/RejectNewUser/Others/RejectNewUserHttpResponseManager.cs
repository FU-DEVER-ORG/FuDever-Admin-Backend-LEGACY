using System;
using System.Collections.Generic;
using FuDever.Application.Features.Admin.RejectNewUser;

namespace FuDever.WebApi.HttpResponseMapper.Admin.RejectNewUser.Others;

/// <summary>
///     Http response manager for reject new user feature.
/// </summary>
internal sealed class RejectNewUserHttpResponseManager
{
    private readonly Dictionary<
        RejectNewUserResponseStatusCode,
        Func<RejectNewUserRequest, RejectNewUserResponse, RejectNewUserHttpResponse>
    > _dictionary;

    internal RejectNewUserHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.USER_IS_NOT_FOUND,
            value: (request, response) =>
                new UserIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new UserIsTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.USER_IS_ALREADY_APPROVED,
            value: (request, response) =>
                new UserIsAlreadyApprovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.USER_IS_ALREADY_REJECTED,
            value: (request, response) =>
                new UserIsAlreadyRejectedHttpResponse(request: request, response: response)
        );

        //_dictionary.Add(
        //    key: RejectNewUserResponseStatusCode.USER_IS_ALREADY_EXPIRED,
        //    value: (request, response) => new UserIsAlreadyExpiredHttpResponse(
        //        request: request,
        //        response: response));

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RejectNewUserResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<RejectNewUserRequest, RejectNewUserResponse, RejectNewUserHttpResponse> Resolve(
        RejectNewUserResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
