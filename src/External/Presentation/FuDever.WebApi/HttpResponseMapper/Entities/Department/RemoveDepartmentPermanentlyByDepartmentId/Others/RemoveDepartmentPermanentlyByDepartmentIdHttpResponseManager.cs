using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.RemoveDepartmentPermanentlyByDepartmentId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.RemoveDepartmentPermanentlyByDepartmentId.Others;

/// <summary>
///     Http response manager for remove department
///     permanently by department id feature.
/// </summary>
internal sealed class RemoveDepartmentPermanentlyByDepartmentIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode,
        Func<
            RemoveDepartmentPermanentlyByDepartmentIdRequest,
            RemoveDepartmentPermanentlyByDepartmentIdResponse,
            RemoveDepartmentPermanentlyByDepartmentIdHttpResponse
        >
    > _dictionary;

    internal RemoveDepartmentPermanentlyByDepartmentIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_FOUND,
            value: (request, response) =>
                new DepartmentIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.DEPARTMENT_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new DepartmentIsNotTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveDepartmentPermanentlyByDepartmentIdRequest,
        RemoveDepartmentPermanentlyByDepartmentIdResponse,
        RemoveDepartmentPermanentlyByDepartmentIdHttpResponse
    > Resolve(RemoveDepartmentPermanentlyByDepartmentIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
