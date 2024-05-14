namespace FuDever.Application.Features.Position.RemovePositionPermanentlyByPositionId;

/// <summary>
///     Extension method for remove position
///     permanently by position id feature.
/// </summary>
public static class RemovePositionPermanentlyByPositionIdExtensionMethods
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
        this RemovePositionPermanentlyByPositionIdResponseStatusCode statusCode
    )
    {
        return $"{nameof(Position)}.{nameof(RemovePositionPermanentlyByPositionId)}.{(int)statusCode}";
    }
}
