using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.RestoreHobbyByHobbyId;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.RestoreHobbyByHobbyId.Others;

/// <summary>
///     Http response manager for restore hobby
///     by hobby id feature.
/// </summary>
internal sealed class RestoreHobbyByHobbyIdHttpResponseManager
{
    private readonly Dictionary<
        RestoreHobbyByHobbyIdResponseStatusCode,
        Func<
            RestoreHobbyByHobbyIdRequest,
            RestoreHobbyByHobbyIdResponse,
            RestoreHobbyByHobbyIdHttpResponse
        >
    > _dictionary;

    internal RestoreHobbyByHobbyIdHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_FOUND,
            value: (request, response) =>
                new HobbyIsNotFoundHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.HOBBY_IS_NOT_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new HobbyIsNotTemporarilyRemovedHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: RestoreHobbyByHobbyIdResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<
        RestoreHobbyByHobbyIdRequest,
        RestoreHobbyByHobbyIdResponse,
        RestoreHobbyByHobbyIdHttpResponse
    > Resolve(RestoreHobbyByHobbyIdResponseStatusCode statusCode)
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
