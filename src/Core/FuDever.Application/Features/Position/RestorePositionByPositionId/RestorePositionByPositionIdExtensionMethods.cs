namespace FuDever.Application.Features.Position.RestorePositionByPositionId;

/// <summary>
///     Extension method for restore position
///     by position id feature.
/// </summary>
public static class RestorePositionByPositionIdExtensionMethods
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
    public static string ToAppCode(this RestorePositionByPositionIdResponseStatusCode statusCode)
    {
        return $"{nameof(Position)}.{nameof(RestorePositionByPositionId)}.{(int)statusCode}";
    }
}
