using System;
using System.Collections.Generic;
using FuDever.Application.Features.Role.GetAllTemporarilyRemovedRoles;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Role.GetAllTemporarilyRemovedRoles.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed roles feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedRolesHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedRolesResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedRolesRequest,
            GetAllTemporarilyRemovedRolesResponse,
            GetAllTemporarilyRemovedRolesHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedRolesHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedRolesResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedRolesResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedRolesResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedRolesResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedRolesRequest,
        GetAllTemporarilyRemovedRolesResponse,
        GetAllTemporarilyRemovedRolesHttpResponse
    > Resolve(GetAllTemporarilyRemovedRolesResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
