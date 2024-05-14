using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.GetAllTemporarilyRemovedMajors.Others;

/// <summary>
///     Http response manager for get all
///     temporarily removed majors feature.
/// </summary>
internal sealed class GetAllTemporarilyRemovedMajorsHttpResponseManager
{
    private readonly Dictionary<
        GetAllTemporarilyRemovedMajorsResponseStatusCode,
        Func<
            GetAllTemporarilyRemovedMajorsRequest,
            GetAllTemporarilyRemovedMajorsResponse,
            GetAllTemporarilyRemovedMajorsHttpResponse
        >
    > _dictionary;

    internal GetAllTemporarilyRemovedMajorsHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllTemporarilyRemovedMajorsResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedMajorsResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedMajorsResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllTemporarilyRemovedMajorsResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        GetAllTemporarilyRemovedMajorsRequest,
        GetAllTemporarilyRemovedMajorsResponse,
        GetAllTemporarilyRemovedMajorsHttpResponse
    > Resolve(GetAllTemporarilyRemovedMajorsResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
