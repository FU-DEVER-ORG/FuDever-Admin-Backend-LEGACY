namespace FuDever.Application.Features.Position.GetAllPositionsByPositionName;

/// <summary>
///     Extension method for get all positions
///     by position name feature.
/// </summary>
public static class GetAllPositionsByPositionNameExtensionMethods
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
    public static string ToAppCode(this GetAllPositionsByPositionNameResponseStatusCode statusCode)
    {
        return $"{nameof(Position)}.{nameof(GetAllPositionsByPositionName)}.{(int)statusCode}";
    }
}
