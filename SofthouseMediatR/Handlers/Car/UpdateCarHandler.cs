﻿using MediatR;
using SofthouseMediatR.Commands.Car;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Car;

public class UpdateCarHandler : IRequestHandler<UpdateCarCommand, UpdateCarResponse>
{
    private readonly ICarService _carService;

    public UpdateCarHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<UpdateCarResponse> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }

        return await _carService.UpdateCarAsync(request.Id, request.UpdateCarRequest);
    }
}
