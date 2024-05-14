using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.GetAllRolesByRoleName;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRolesByRoleName.Others;

/// <summary>
///     Http response manager for get all roles
///     by role name feature.
/// </summary>
internal sealed class GetAllRolesByRoleNameHttpResponseManager
{
    private readonly Dictionary<
        GetAllRolesByRoleNameResponseStatusCode,
        Func<
            GetAllRolesByRoleNameRequest,
            GetAllRolesByRoleNameResponse,
            GetAllRolesByRoleNameHttpResponse
        >
    > _dictionary;

    internal GetAllRolesByRoleNameHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllRolesByRoleNameResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllRolesByRoleNameResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllRolesByRoleNameRequest,
        GetAllRolesByRoleNameResponse,
        GetAllRolesByRoleNameHttpResponse
    > Resolve(GetAllRolesByRoleNameResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
