namespace FuDever.Application.Shared.DataProtection;

/// <summary>
///     Interface for data protection handler.
/// </summary>
public interface IDataProtectionHandler
{
    /// <summary>
    ///     Protects the plain text.
    /// </summary>
    /// <param name="plainText">
    ///     The plain text.
    /// </param>
    /// <returns>
    ///     Encrypted text.
    /// </returns>
    string Protect(string plainText);

    /// <summary>
    ///     Unprotects the protected text.
    /// </summary>
    /// <param name="protectedText">
    ///     The protected text.
    /// </param>
    /// <returns>
    ///     Plain text.
    /// </returns>
    string Unprotect(string protectedText);
}
