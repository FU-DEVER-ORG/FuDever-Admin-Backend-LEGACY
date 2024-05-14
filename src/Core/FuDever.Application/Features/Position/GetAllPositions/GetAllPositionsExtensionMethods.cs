namespace FuDever.Application.Features.Position.GetAllPositions;

/// <summary>
///     Extension method for get all position feature.
/// </summary>
public static class GetAllPositionsExtensionMethods
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
    public static string ToAppCode(this GetAllPositionsResponseStatusCode statusCode)
    {
        return $"{nameof(Position)}.{nameof(GetAllPositions)}.{(int)statusCode}";
    }
}
