using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.RestoreMajorByMajorId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RestoreMajorByMajorId.Others;

/// <summary>
///     Http response manager for restore major
///     by major id feature.
/// </summary>
internal sealed class RestoreMajorByMajorIdHttpResponseManager
{
    private readonly Dictionary<
        RestoreMajorByMajorIdResponseStatusCode,
        Func<
            RestoreMajorByMajorIdRequest,
            RestoreMajorByMajorIdResponse,
            RestoreMajorByMajorIdHttpResponse
        >
    > _dictionary;

    internal RestoreMajorByMajorIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND,
            value: (request, response) =>
                new MajorIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.MAJOR_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new MajorIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreMajorByMajorIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestoreMajorByMajorIdRequest,
        RestoreMajorByMajorIdResponse,
        RestoreMajorByMajorIdHttpResponse
    > Resolve(RestoreMajorByMajorIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
