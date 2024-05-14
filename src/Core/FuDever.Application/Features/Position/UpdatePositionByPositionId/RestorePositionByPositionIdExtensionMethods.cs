namespace FuDever.Application.Features.Position.UpdatePositionByPositionId;

/// <summary>
///     Extension method for update position
///     by position id feature.
/// </summary>
public static class UpdatePositionByPositionIdExtensionMethods
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
    public static string ToAppCode(this UpdatePositionByPositionIdResponseStatusCode statusCode)
    {
        return $"{nameof(Position)}.{nameof(UpdatePositionByPositionId)}.{(int)statusCode}";
    }
}
