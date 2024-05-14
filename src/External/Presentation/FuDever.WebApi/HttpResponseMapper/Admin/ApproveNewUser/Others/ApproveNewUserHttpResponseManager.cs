using System;
using System.Collections.Generic;
using FuDever.Application.Features.Admin.ApproveNewUser;

namespace FuDever.WebApi.HttpResponseMapper.Admin.ApproveNewUser.Others;

/// <summary>
///     Http response manager for approve new user feature.
/// </summary>
internal sealed class ApproveNewUserHttpResponseManager
{
    private readonly Dictionary<
        ApproveNewUserResponseStatusCode,
        Func<ApproveNewUserRequest, ApproveNewUserResponse, ApproveNewUserHttpResponse>
    > _dictionary;

    internal ApproveNewUserHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.USER_IS_NOT_FOUND,
            value: (request, response) =>
                new UserIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.USER_IS_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new UserIsTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.USER_IS_ALREADY_APPROVED,
            value: (request, response) =>
                new UserIsAlreadyApprovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.USER_IS_ALREADY_REJECTED,
            value: (request, response) =>
                new UserIsAlreadyRejectedHttpResponse(request: request, response: response)
        );

        //_dictionary.Add(
        //    key: ApproveNewUserResponseStatusCode.USER_IS_ALREADY_EXPIRED,
        //    value: (request, response) => new UserIsAlreadyExpiredHttpResponse(
        //        request: request,
        //        response: response));

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: ApproveNewUserResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        ApproveNewUserRequest,
        ApproveNewUserResponse,
        ApproveNewUserHttpResponse
    > Resolve(ApproveNewUserResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
