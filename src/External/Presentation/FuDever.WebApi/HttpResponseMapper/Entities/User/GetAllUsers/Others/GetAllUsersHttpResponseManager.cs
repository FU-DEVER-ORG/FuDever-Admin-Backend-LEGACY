using System;
using System.Collections.Generic;
using FuDever.Application.Features.User.GetAllUsers;

namespace FuDever.WebApi.HttpResponseMapper.Entities.User.GetAllUsers.Others;

/// <summary>
///     Http response manager for get all users feature.
/// </summary>
internal sealed class GetAllUsersHttpResponseManager
{
    private readonly Dictionary<
        GetAllUsersResponseStatusCode,
        Func<GetAllUsersRequest, GetAllUsersResponse, GetAllUsersHttpResponse>
    > _dictionary;

    internal GetAllUsersHttpResponseManager()
    {
        _dictionary = [];

        _dictionary.Add(
            key: GetAllUsersResponseStatusCode.INPUT_VALIDATION_FAIL,
            value: (_, response) => new InputValidationFailHttpResponse(response: response)
        );

        _dictionary.Add(
            key: GetAllUsersResponseStatusCode.OPERATION_SUCCESS,
            value: (_, response) => new OperationSuccessHttpResponse(response: response)
        );
    }

    internal Func<GetAllUsersRequest, GetAllUsersResponse, GetAllUsersHttpResponse> Resolve(
        GetAllUsersResponseStatusCode statusCode
    )
    {
        return _dictionary.GetValueOrDefault(key: statusCode);
    }
}
