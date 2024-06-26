namespace SofthouseWorker.Settings;

public class SmtpSettings
{
    public string Server { get; set; } = string.Empty;

    public int Port { get; set; }

    public bool UseSsl { get; set; }

    public string From { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
