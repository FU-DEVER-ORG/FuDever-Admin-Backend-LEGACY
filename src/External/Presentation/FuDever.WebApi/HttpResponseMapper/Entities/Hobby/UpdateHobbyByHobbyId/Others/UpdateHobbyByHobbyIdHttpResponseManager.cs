using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.UpdateHobbyByHobbyId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.UpdateHobbyByHobbyId.Others;

/// <summary>
///     Http response manager for update hobby
///     by hobby id feature.
/// </summary>
internal sealed class UpdateHobbyByHobbyIdHttpResponseManager
{
    private readonly Dictionary<
        UpdateHobbyByHobbyIdResponseStatusCode,
        Func<
            UpdateHobbyByHobbyIdRequest,
            UpdateHobbyByHobbyIdResponse,
            UpdateHobbyByHobbyIdHttpResponse
        >
    > _dictionary;

    internal UpdateHobbyByHobbyIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.HOBBY_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new HobbyIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.HOBBY_ALREADY_EXISTS,
            value: (request, response) =>
                new HobbyAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND,
            value: (request, response) =>
                new HobbyIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: UpdateHobbyByHobbyIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        UpdateHobbyByHobbyIdRequest,
        UpdateHobbyByHobbyIdResponse,
        UpdateHobbyByHobbyIdHttpResponse
    > Resolve(UpdateHobbyByHobbyIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
