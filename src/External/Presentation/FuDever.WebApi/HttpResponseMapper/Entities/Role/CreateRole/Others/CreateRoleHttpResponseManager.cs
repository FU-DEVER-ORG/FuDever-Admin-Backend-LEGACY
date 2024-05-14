using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.CreateRole;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.CreateRole.Others;

/// <summary>
///     Http response manager for create role feature.
/// </summary>
internal sealed class CreateRoleHttpResponseManager
{
    private readonly Dictionary<
        CreateRoleResponseStatusCode,
        Func<CreateRoleRequest, CreateRoleResponse, CreateRoleHttpResponse>
    > _dictionary;

    internal CreateRoleHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.ROLE_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new RoleIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.ROLE_ALREADY_EXISTS,
            value: (request, response) =>
                new RoleAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateRoleResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<CreateRoleRequest, CreateRoleResponse, CreateRoleHttpResponse> Resolve(
        CreateRoleResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
