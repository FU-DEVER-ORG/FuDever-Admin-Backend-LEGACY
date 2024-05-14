﻿namespace FuDever.Application.Features.Major.GetAllTemporarilyRemovedMajors;

/// <summary>
///     Get all temporarily removed majors response status code.
/// </summary>
public enum GetAllTemporarilyRemovedMajorsResponseStatusCode
{
    INPUT_VALIDATION_FAIL,
    OPERATION_SUCCESS,
    FORBIDDEN,
    UN_AUTHORIZED
}
