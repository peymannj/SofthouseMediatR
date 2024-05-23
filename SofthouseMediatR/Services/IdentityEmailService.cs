using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SofthouseMediatR.Services.Interfaces;
using SofthouseMediatR.Settings;

namespace SofthouseMediatR.Services;

public class IdentityEmailService : IEmailSender<IdentityUser>
{
	private readonly SmtpSettings _smtpSettings;
	private readonly IEmailService _emailService;

	public IdentityEmailService(IEmailService emailService, IOptions<SmtpSettings> smtpSettings)
	{
		_emailService = emailService;
		_smtpSettings = smtpSettings.Value;
	}

	public async Task SendConfirmationLinkAsync(IdentityUser user, string email, string confirmationLink)
	{
		await _emailService.SendAsync(_smtpSettings.From, email, "Confirmation Link", confirmationLink);
	}

	public async Task SendPasswordResetLinkAsync(IdentityUser user, string email, string resetLink)
	{
		await _emailService.SendAsync(_smtpSettings.From, email, "Password Reset Link", resetLink);
	}

	public async Task SendPasswordResetCodeAsync(IdentityUser user, string email, string resetCode)
	{
		await _emailService.SendAsync(_smtpSettings.From, email, "Password Reset Code", resetCode);
	}
}
