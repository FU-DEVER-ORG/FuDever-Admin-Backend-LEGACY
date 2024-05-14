using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.RemoveHobbyPermanentlyByHobbyId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyPermanentlyByHobbyId.Others;

/// <summary>
///     Http response manager for remove hobby
///     permanently by hobby id feature.
/// </summary>
internal sealed class RemoveHobbyPermanentlyByHobbyIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveHobbyPermanentlyByHobbyIdResponseStatusCode,
        Func<
            RemoveHobbyPermanentlyByHobbyIdRequest,
            RemoveHobbyPermanentlyByHobbyIdResponse,
            RemoveHobbyPermanentlyByHobbyIdHttpResponse
        >
    > _dictionary;

    internal RemoveHobbyPermanentlyByHobbyIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND,
            value: (request, response) =>
                new HobbyIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new HobbyIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyPermanentlyByHobbyIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveHobbyPermanentlyByHobbyIdRequest,
        RemoveHobbyPermanentlyByHobbyIdResponse,
        RemoveHobbyPermanentlyByHobbyIdHttpResponse
    > Resolve(RemoveHobbyPermanentlyByHobbyIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
