using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.GetAllRoles;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllRoles.Others;

/// <summary>
///     Http response manager for get all roles feature.
/// </summary>
internal sealed class GetAllRolesHttpResponseManager
{
    private readonly Dictionary<
        GetAllRolesResponseStatusCode,
        Func<GetAllRolesRequest, GetAllRolesResponse, GetAllRolesHttpResponse>
    > _dictionary;

    internal GetAllRolesHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllRolesResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllRolesResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<GetAllRolesRequest, GetAllRolesResponse, GetAllRolesHttpResponse> Resolve(
        GetAllRolesResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
