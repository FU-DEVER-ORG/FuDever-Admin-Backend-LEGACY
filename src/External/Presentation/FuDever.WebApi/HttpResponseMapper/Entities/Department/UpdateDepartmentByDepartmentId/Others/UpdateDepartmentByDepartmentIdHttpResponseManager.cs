using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.UpdateDepartmentByDepartmentId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.UpdateDepartmentByDepartmentId.Others;

/// <summary>
///     Http response manager for update department
///     by department id feature.
/// </summary>
internal sealed class UpdateDepartmentByDepartmentIdHttpResponseManager
{
    private readonly Dictionary<
        UpdateDepartmentByDepartmentIdResponseStatusCode,
        Func<
            UpdateDepartmentByDepartmentIdRequest,
            UpdateDepartmentByDepartmentIdResponse,
            UpdateDepartmentByDepartmentIdHttpResponse
        >
    > _dictionary;

    internal UpdateDepartmentByDepartmentIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new DepartmentIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_ALREADY_EXISTS,
            value: (request, response) =>
                new DepartmentAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND,
            value: (request, response) =>
                new DepartmentIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateDepartmentByDepartmentIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdateDepartmentByDepartmentIdRequest,
        UpdateDepartmentByDepartmentIdResponse,
        UpdateDepartmentByDepartmentIdHttpResponse
    > Resolve(UpdateDepartmentByDepartmentIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
