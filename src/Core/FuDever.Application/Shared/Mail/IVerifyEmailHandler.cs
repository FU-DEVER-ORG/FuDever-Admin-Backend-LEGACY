using System.Threading.Tasks;

namespace FuDever.Application.Shared.Mail;

/// <summary>
///     Represent interface of mail verification.
/// </summary>
public interface IVerifyEmailHandler
{
    /// <summary>
    ///     Validate if the email is real or not.
    /// </summary>
    /// <param name="email">
    ///     User email
    /// </param>
    /// <returns>
    ///     True if email is exist. Otherwise, false.
    /// </returns>
    Task<bool> IsEmailRealAsync(string email);
}
