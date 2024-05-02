using MailKit.Net.Smtp;
using MassTransit;
using Microsoft.Extensions.Options;
using MimeKit;
using SofthouseWorker.Services.Interfaces;
using SofthouseWorker.Settings;

namespace SofthouseWorker.Services;

public class EMailService : IEMailService
{
    private readonly SmtpSettings _options;

    public EMailService(IOptions<SmtpSettings> options)
    {
        _options = options.Value ?? throw new ConfigurationException("Smtp configuration must be provided");
    }

    public async Task SendAsync(string from, string to, string subject, string body)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(string.Empty, _options.From));
        message.To.Add(new MailboxAddress(string.Empty, to));
        message.Subject = subject;

        var builder = new BodyBuilder();
        builder.HtmlBody = body;

        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        await client.ConnectAsync(_options.Server, _options.Port, _options.UseSsl);
        //await client.AuthenticateAsync(_options.Username, _options.Password);
        
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
