namespace FuDever.Application.Features.Position.GetAllTemporarilyRemovedPositions;

/// <summary>
///     Extension method for get all temporarily
///     removed positions feature.
/// </summary>
public static class GetAllTemporarilyRemovedPositionsExtensionMethods
{
    /// <summary>
    ///     Mapping from feature response status code to
    ///     app code.
    /// </summary>
    /// <param name="statusCode">
    ///     Feature response status code
    /// </param>
    /// <returns>
    ///     New app code.
    /// </returns>
    public static string ToAppCode(
        this GetAllTemporarilyRemovedPositionsResponseStatusCode statusCode
    )
    {
        return $"{nameof(Position)}.{nameof(GetAllTemporarilyRemovedPositions)}.{(int)statusCode}";
    }
}
