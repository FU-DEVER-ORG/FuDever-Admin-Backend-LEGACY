using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.UpdateRoleByRoleId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.UpdateRoleByRoleId.Others;

/// <summary>
///     Http response manager for update role
///     by role id feature.
/// </summary>
internal sealed class UpdateRoleByRoleIdHttpResponseManager
{
    private readonly Dictionary<
        UpdateRoleByRoleIdResponseStatusCode,
        Func<UpdateRoleByRoleIdRequest, UpdateRoleByRoleIdResponse, UpdateRoleByRoleIdHttpResponse>
    > _dictionary;

    internal UpdateRoleByRoleIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.ROLE_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new RoleIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.ROLE_ALREADY_EXISTS,
            value: (request, response) =>
                new RoleAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.ROLE_IS_NOT_FOUND,
            value: (request, response) =>
                new RoleIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateRoleByRoleIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdateRoleByRoleIdRequest,
        UpdateRoleByRoleIdResponse,
        UpdateRoleByRoleIdHttpResponse
    > Resolve(UpdateRoleByRoleIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
