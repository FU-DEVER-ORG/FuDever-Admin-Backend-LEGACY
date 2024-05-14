using FuDever.Application.Shared.Mail;
using FuDever.Configuration.Infrastructure.Mail.GoogleGmail;
using FuDever.GoogleSmtp.Handler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FuDever.GoogleSmtp;

/// <summary>
///     Configure services for this layer.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    ///     Entry to configuring multiple services.
    /// </summary>
    /// <param name="services">
    ///     Service container.
    /// </param>
    /// <param name="configuration">
    ///     Configuration manager.
    /// </param>
    public static void AddGoogleSmtpMailNotification(
        this IServiceCollection services,
        IConfigurationManager configuration
    )
    {
        services
            .AddSingleton<ISendingMailHandler, GoogleSendingMailHandler>()
            .AddSingleton(
                configuration
                    .GetRequiredSection(key: "MailSending")
                    .GetRequiredSection(key: "GoogleGmail")
                    .Get<GoogleGmailSendingOption>()
            );
    }
}
