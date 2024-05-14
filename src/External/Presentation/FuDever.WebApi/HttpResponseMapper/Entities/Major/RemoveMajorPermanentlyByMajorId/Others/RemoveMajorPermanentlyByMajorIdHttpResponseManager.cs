using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.RemoveMajorPermanentlyByMajorId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.RemoveMajorPermanentlyByMajorId.Others;

/// <summary>
///     Http response manager for remove major
///     permanently by major id feature.
/// </summary>
internal sealed class RemoveMajorPermanentlyByMajorIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveMajorPermanentlyByMajorIdResponseStatusCode,
        Func<
            RemoveMajorPermanentlyByMajorIdRequest,
            RemoveMajorPermanentlyByMajorIdResponse,
            RemoveMajorPermanentlyByMajorIdHttpResponse
        >
    > _dictionary;

    internal RemoveMajorPermanentlyByMajorIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.MAJOR_IS_NOT_FOUND,
            value: (request, response) =>
                new MajorIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.MAJOR_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new MajorIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveMajorPermanentlyByMajorIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveMajorPermanentlyByMajorIdRequest,
        RemoveMajorPermanentlyByMajorIdResponse,
        RemoveMajorPermanentlyByMajorIdHttpResponse
    > Resolve(RemoveMajorPermanentlyByMajorIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
