﻿namespace SofthouseWorker.Services.Interfaces;

public interface IEmailService
{
    Task SendAsync(string from, string to, string subject, string body);
}
