using System;
using System.Threading.Tasks;
using FuDever.Application.Shared.Mail;

namespace FuDever.GoogleSmtp.Handler;

internal sealed class GoogleVerifyEmailHandlerHandler : IVerifyEmailHandler
{
    public Task<bool> IsEmailRealAsync(string email)
    {
        throw new NotImplementedException();
    }
}
