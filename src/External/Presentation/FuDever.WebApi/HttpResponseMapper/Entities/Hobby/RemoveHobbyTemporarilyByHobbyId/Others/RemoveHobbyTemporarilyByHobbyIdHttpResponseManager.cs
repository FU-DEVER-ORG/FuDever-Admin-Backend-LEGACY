using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.RemoveHobbyTemporarilyByHobbyId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RemoveHobbyTemporarilyByHobbyId.Others;

/// <summary>
///     Http response manager for remove hobby
///     temporarily by hobby id feature.
/// </summary>
internal sealed class RemoveHobbyTemporarilyByHobbyIdHttpResponseManager
{
    private readonly Dictionary<
        RemoveHobbyTemporarilyByHobbyIdResponseStatusCode,
        Func<
            RemoveHobbyTemporarilyByHobbyIdRequest,
            RemoveHobbyTemporarilyByHobbyIdResponse,
            RemoveHobbyTemporarilyByHobbyIdHttpResponse
        >
    > _dictionary;

    internal RemoveHobbyTemporarilyByHobbyIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND,
            value: (request, response) =>
                new HobbyIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.HOBBY_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new HobbyIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RemoveHobbyTemporarilyByHobbyIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RemoveHobbyTemporarilyByHobbyIdRequest,
        RemoveHobbyTemporarilyByHobbyIdResponse,
        RemoveHobbyTemporarilyByHobbyIdHttpResponse
    > Resolve(RemoveHobbyTemporarilyByHobbyIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
