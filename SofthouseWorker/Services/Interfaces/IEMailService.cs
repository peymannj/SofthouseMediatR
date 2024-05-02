namespace SofthouseWorker.Services.Interfaces;

public interface IEMailService
{
    Task SendAsync(string from, string to, string subject, string body);
}
