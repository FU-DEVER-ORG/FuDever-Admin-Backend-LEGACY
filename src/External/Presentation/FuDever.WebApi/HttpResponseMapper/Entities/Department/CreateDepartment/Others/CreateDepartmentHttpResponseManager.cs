using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.CreateDepartment;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.CreateDepartment.Others;

/// <summary>
///     Http response manager for create department feature.
/// </summary>
internal sealed class CreateDepartmentHttpResponseManager
{
    private readonly Dictionary<
        CreateDepartmentResponseStatusCode,
        Func<CreateDepartmentRequest, CreateDepartmentResponse, CreateDepartmentHttpResponse>
    > _dictionary;

    internal CreateDepartmentHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.DEPARTMENT_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new DepartmentIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.DEPARTMENT_ALREADY_EXISTS,
            value: (request, response) =>
                new DepartmentAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateDepartmentResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        CreateDepartmentRequest,
        CreateDepartmentResponse,
        CreateDepartmentHttpResponse
    > Resolve(CreateDepartmentResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
