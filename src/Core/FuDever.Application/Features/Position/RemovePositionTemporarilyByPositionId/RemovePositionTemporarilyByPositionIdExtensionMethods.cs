namespace FuDever.Application.Features.Position.RemovePositionTemporarilyByPositionId;

/// <summary>
///     Extension method for remove position
///     temporarily by position id feature.
/// </summary>
public static class RemovePositionTemporarilyByPositionIdExtensionMethods
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
        this RemovePositionTemporarilyByPositionIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Position)}.{nameof(RemovePositionTemporarilyByPositionId)}.{(int)statusCode}";
    }
}
