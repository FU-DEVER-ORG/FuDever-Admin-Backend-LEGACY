namespace FuDever.Application.Features.Position.CreatePosition;

/// <summary>
///     Extension method for create position feature.
/// </summary>
public static class CreatePositionExtensionMethods
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
    public static string ToAppCode(this CreatePositionResponseStatusCode statusCode)
    {
        return $"{nameof(Position)}.{nameof(CreatePosition)}.{(int)statusCode}";
    }
}
