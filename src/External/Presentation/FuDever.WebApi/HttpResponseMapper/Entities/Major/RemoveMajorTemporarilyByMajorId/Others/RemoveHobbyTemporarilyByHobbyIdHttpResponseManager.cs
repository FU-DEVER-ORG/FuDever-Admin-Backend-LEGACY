using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.RemoveMajorTemporarilyByMajorId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorTemporarilyByMajorId.Others;

/// <summary>
///     Http response manager for remove major
///     temporarily by major id feature.
/// </summary>
internal sealed class RemoveMajorTemporarilyByMajorIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveMajorTemporarilyByMajorIdResponseStatusCode,
        Func<
            RemoveMajorTemporarilyByMajorIdRequest,
            RemoveMajorTemporarilyByMajorIdResponse,
            RemoveMajorTemporarilyByMajorIdHttpResponse
        >
    > _dictionary;

    internal RemoveMajorTemporarilyByMajorIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND,
            value: (request, response) =>
                new MajorIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.MAJOR_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new MajorIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorTemporarilyByMajorIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveMajorTemporarilyByMajorIdRequest,
        RemoveMajorTemporarilyByMajorIdResponse,
        RemoveMajorTemporarilyByMajorIdHttpResponse
    > Resolve(RemoveMajorTemporarilyByMajorIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
