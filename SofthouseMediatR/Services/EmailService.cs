using MailKit.Net.Smtp;
using MassTransit;
using Microsoft.Extensions.Options;
using MimeKit;
using SofthouseMediatR.Services.Interfaces;
using SofthouseMediatR.Settings;

namespace SofthouseMediatR.Services;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _options;

    public EmailService(IOptions<SmtpSettings> options)
    {
        _options = options.Value ?? throw new ConfigurationException("Smtp configuration must be provided");
    }

    public async Task SendAsync(string from, string to, string subject, string body)
    {
        var emailMessage = new MimeMessage();
        emailMessage.Subject = subject;
        emailMessage.To.Add(new MailboxAddress(string.Empty, to));
        emailMessage.From.Add(new MailboxAddress(string.Empty, string.IsNullOrWhiteSpace(from) ? _options.From : from));

        var builder = new BodyBuilder { HtmlBody = body };
        emailMessage.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        await client.ConnectAsync(_options.Server, _options.Port, _options.UseSsl);
        await client.AuthenticateAsync(_options.Username, _options.Password);
        
        await client.SendAsync(emailMessage);
        await client.DisconnectAsync(true);
    }
}
