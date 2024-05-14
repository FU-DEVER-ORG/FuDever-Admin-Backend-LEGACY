using System.Security.Cryptography;
using FuDever.Application.DataProtection;
using FuDever.Configuration.Presentation.WebApi.DataProtection;
using Microsoft.AspNetCore.DataProtection;

namespace FuDever.AppDataProtection.Handler;

/// <summary>
///     Implementation of app data protection handler.
/// </summary>
internal sealed class AppDataProtectionHandler : IDataProtectionHandler
{
    private readonly IDataProtector _dataProtector;

    public AppDataProtectionHandler(
        IDataProtectionProvider dataProtectionProvider,
        DataProtectionOption dataProtectionOption
    )
    {
        _dataProtector = dataProtectionProvider.CreateProtector(purpose: dataProtectionOption.Key);
    }

    public string Protect(string plainText)
    {
        return _dataProtector.Protect(plaintext: plainText);
    }

    public string Unprotect(string protectedText)
    {
        try
        {
            return _dataProtector.Unprotect(protectedData: protectedText);
        }
        catch (CryptographicException)
        {
            return string.Empty;
        }
    }
}
