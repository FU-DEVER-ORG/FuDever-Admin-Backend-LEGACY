using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.GetAllMajors;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllMajors.Others;

/// <summary>
///     Http response manager for get all majors feature.
/// </summary>
internal sealed class GetAllMajorsHttpResponseManager
{
    private readonly Dictionary<
        GetAllMajorsResponseStatusCode,
        Func<GetAllMajorsRequest, GetAllMajorsResponse, GetAllMajorsHttpResponse>
    > _dictionary;

    internal GetAllMajorsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllMajorsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllMajorsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<GetAllMajorsRequest, GetAllMajorsResponse, GetAllMajorsHttpResponse> Resolve(
        GetAllMajorsResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
