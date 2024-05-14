using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.RemoveDepartmentTemporarilyByDepartmentId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentTemporarilyByDepartmentId.Others;

/// <summary>
///     Http response manager for remove department
///     temporarily by department id feature.
/// </summary>
internal sealed class RemoveDepartmentTemporarilyByDepartmentIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode,
        Func<
            RemoveDepartmentTemporarilyByDepartmentIdRequest,
            RemoveDepartmentTemporarilyByDepartmentIdResponse,
            RemoveDepartmentTemporarilyByDepartmentIdHttpResponse
        >
    > _dictionary;

    internal RemoveDepartmentTemporarilyByDepartmentIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND,
            value: (request, response) =>
                new DepartmentIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new DepartmentIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveDepartmentTemporarilyByDepartmentIdRequest,
        RemoveDepartmentTemporarilyByDepartmentIdResponse,
        RemoveDepartmentTemporarilyByDepartmentIdHttpResponse
    > Resolve(RemoveDepartmentTemporarilyByDepartmentIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
