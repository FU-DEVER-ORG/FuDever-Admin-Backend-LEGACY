using System;
using System.Collections.Generic;
using FuDever.Application.Features.Department.GetAllDepartments;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Department.GetAllDepartments.Others;

/// <summary>
///     Http response manager for get all departments feature.
/// </summary>
internal sealed class GetAllDepartmentsHttpResponseManager
{
    private readonly Dictionary<
        GetAllDepartmentsResponseStatusCode,
        Func<GetAllDepartmentsRequest, GetAllDepartmentsResponse, GetAllDepartmentsHttpResponse>
    > _dictionary;

    internal GetAllDepartmentsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllDepartmentsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllDepartmentsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllDepartmentsRequest,
        GetAllDepartmentsResponse,
        GetAllDepartmentsHttpResponse
    > Resolve(GetAllDepartmentsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
