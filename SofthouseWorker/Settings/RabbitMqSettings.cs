namespace SofthouseWorker.Settings;

public class RabbitMqSettings
{
    public string HostName { get; set; } = "localhost";

    public int Port { get; set; } = 5672;

    public string Username { get; set; } = "guest";

    public string Password { get; set; } = "guest";
}
