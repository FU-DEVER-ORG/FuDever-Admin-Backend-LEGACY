using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.RestoreRoleByRoleId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RestoreRoleByRoleId.Others;

/// <summary>
///     Http response manager for restore role
///     by role id feature.
/// </summary>
internal sealed class RestoreRoleByRoleIdHttpResponseManager
{
    private readonly Dictionary<
        RestoreRoleByRoleIdResponseStatusCode,
        Func<
            RestoreRoleByRoleIdRequest,
            RestoreRoleByRoleIdResponse,
            RestoreRoleByRoleIdHttpResponse
        >
    > _dictionary;

    internal RestoreRoleByRoleIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND,
            value: (request, response) =>
                new RoleIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.ROLE_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new RoleIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreRoleByRoleIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestoreRoleByRoleIdRequest,
        RestoreRoleByRoleIdResponse,
        RestoreRoleByRoleIdHttpResponse
    > Resolve(RestoreRoleByRoleIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
