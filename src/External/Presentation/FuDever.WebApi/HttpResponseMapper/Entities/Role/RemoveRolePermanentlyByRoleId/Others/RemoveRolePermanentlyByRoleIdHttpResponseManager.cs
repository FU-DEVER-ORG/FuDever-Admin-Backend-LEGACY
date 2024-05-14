using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.RemoveRolePermanentlyByRoleId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RemoveRolePermanentlyByRoleId.Others;

/// <summary>
///     Http response manager for remove role
///     permanently by role id feature.
/// </summary>
internal sealed class RemoveRolePermanentlyByRoleIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveRolePermanentlyByRoleIdResponseStatusCode,
        Func<
            RemoveRolePermanentlyByRoleIdRequest,
            RemoveRolePermanentlyByRoleIdResponse,
            RemoveRolePermanentlyByRoleIdHttpResponse
        >
    > _dictionary;

    internal RemoveRolePermanentlyByRoleIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND,
            value: (request, response) =>
                new RoleIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.ROLE_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new RoleIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRolePermanentlyByRoleIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveRolePermanentlyByRoleIdRequest,
        RemoveRolePermanentlyByRoleIdResponse,
        RemoveRolePermanentlyByRoleIdHttpResponse
    > Resolve(RemoveRolePermanentlyByRoleIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
