using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.RemoveRoleTemporarilyByRoleId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.RemoveRoleTemporarilyByRoleId.Others;

/// <summary>
///     Http response manager for remove role
///     temporarily by role id feature.
/// </summary>
internal sealed class RemoveRoleTemporarilyByRoleIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveRoleTemporarilyByRoleIdResponseStatusCode,
        Func<
            RemoveRoleTemporarilyByRoleIdRequest,
            RemoveRoleTemporarilyByRoleIdResponse,
            RemoveRoleTemporarilyByRoleIdHttpResponse
        >
    > _dictionary;

    internal RemoveRoleTemporarilyByRoleIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND,
            value: (request, response) =>
                new RoleIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.ROLE_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new RoleIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveRoleTemporarilyByRoleIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveRoleTemporarilyByRoleIdRequest,
        RemoveRoleTemporarilyByRoleIdResponse,
        RemoveRoleTemporarilyByRoleIdHttpResponse
    > Resolve(RemoveRoleTemporarilyByRoleIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
