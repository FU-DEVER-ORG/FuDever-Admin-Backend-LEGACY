using System;
using System.Collections.Generic;
using FuDever.Application.Features.Hobby.CreateHobby;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Hobby.CreateHobby.Others;

/// <summary>
///     Http response manager for create hobby feature.
/// </summary>
internal sealed class CreateHobbyHttpResponseManager
{
    private readonly Dictionary<
        CreateHobbyResponseStatusCode,
        Func<CreateHobbyRequest, CreateHobbyResponse, CreateHobbyHttpResponse>
    > _dictionary;

    internal CreateHobbyHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.HOBBY_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new HobbyIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.HOBBY_ALREADY_EXISTS,
            value: (request, response) =>
                new HobbyAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateHobbyResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<CreateHobbyRequest, CreateHobbyResponse, CreateHobbyHttpResponse> Resolve(
        CreateHobbyResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
