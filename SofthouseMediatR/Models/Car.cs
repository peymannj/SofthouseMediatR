﻿namespace SofthouseMediatR.Models;

public class Car
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;
}
