using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.RestoreDepartmentByDepartmentId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RestoreDepartmentByDepartmentId.Others;

/// <summary>
///     Http response manager for restore department
///     by department id feature.
/// </summary>
internal sealed class RestoreDepartmentByDepartmentIdHttpResponseManager
{
    private readonly Dictionary<
        RestoreDepartmentByDepartmentIdResponseStatusCode,
        Func<
            RestoreDepartmentByDepartmentIdRequest,
            RestoreDepartmentByDepartmentIdResponse,
            RestoreDepartmentByDepartmentIdHttpResponse
        >
    > _dictionary;

    internal RestoreDepartmentByDepartmentIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND,
            value: (request, response) =>
                new DepartmentIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new DepartmentIsNotTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreDepartmentByDepartmentIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestoreDepartmentByDepartmentIdRequest,
        RestoreDepartmentByDepartmentIdResponse,
        RestoreDepartmentByDepartmentIdHttpResponse
    > Resolve(RestoreDepartmentByDepartmentIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
