using System;
using System.Collections.Generic;
using FuDever.Application.Features.Major.CreateMajor;

namespace FuDever.WebApi.HttpResponseMapper.Entities.Major.CreateMajor.Others;

/// <summary>
///     Http response manager for create major feature.
/// </summary>
internal sealed class CreateMajorHttpResponseManager
{
    private readonly Dictionary<
        CreateMajorResponseStatusCode,
        Func<CreateMajorRequest, CreateMajorResponse, CreateMajorHttpResponse>
    > _dictionary;

    internal CreateMajorHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.DATABASE_OPERATION_FAIL,
            value: (_, response) => new DatabaseOperationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.MAJOR_IS_ALREADY_TEMPORARILY_REMOVED,
            value: (request, response) =>
                new MajorIsAlreadyTemporarilyRemovedHttpResponse(
                    request: request,
                    response: response
                )
        );

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.MAJOR_ALREADY_EXISTS,
            value: (request, response) =>
                new MajorAlreadyExistsHttpResponse(request: request, response: response)
        );

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.UN_AUTHORIZED,
            value: (_, response) => new UnAuthorizedHttpResponse(response: response)
        );

        _dictionary.Add(
            key: CreateMajorResponseStatusCode.FORBIDDEN,
            value: (_, response) => new ForbiddenHttpResponse(response: response)
        );
    }

    internal Func<CreateMajorRequest, CreateMajorResponse, CreateMajorHttpResponse> Resolve(
        CreateMajorResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
