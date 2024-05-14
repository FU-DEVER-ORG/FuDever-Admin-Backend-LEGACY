using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.GetAllTemporarilyRemovedDepartments;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllTemporarilyRemovedDepartments.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed departments feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedDepartmentsHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedDepartmentsResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedDepartmentsRequest,
            GetAllTemporarilyRemovedDepartmentsResponse,
            GetAllTemporarilyRemovedDepartmentsHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedDepartmentsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedDepartmentsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedDepartmentsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedDepartmentsResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedDepartmentsResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedDepartmentsRequest,
        GetAllTemporarilyRemovedDepartmentsResponse,
        GetAllTemporarilyRemovedDepartmentsHttpResponse
    > Resolve(GetAllTemporarilyRemovedDepartmentsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
