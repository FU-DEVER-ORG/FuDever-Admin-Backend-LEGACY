using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.UpdateMajorByMajorId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.UpdateMajorByMajorId.Others;

/// <summary>
///     Http response manager for update major
///     by major id feature.
/// </summary>
internal sealed class UpdateMajorByMajorIdHttpResponseManager
{
    private readonly Dictionary<
        UpdateMajorByMajorIdResponseStatusCode,
        Func<
            UpdateMajorByMajorIdRequest,
            UpdateMajorByMajorIdResponse,
            UpdateMajorByMajorIdHttpResponse
        >
    > _dictionary;

    internal UpdateMajorByMajorIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.MAJOR_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new MajorIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.MAJOR_ALREADY_EXISTS,
            value: (request, response) =>
                new MajorAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND,
            value: (request, response) =>
                new MajorIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateMajorByMajorIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdateMajorByMajorIdRequest,
        UpdateMajorByMajorIdResponse,
        UpdateMajorByMajorIdHttpResponse
    > Resolve(UpdateMajorByMajorIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
