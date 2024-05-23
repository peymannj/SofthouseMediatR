using MediatR;
using SofthouseMediatR.Commands.Car;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Car;

public class CreateCarHandler : IRequestHandler<CreateCarCommand, CreateCarResponse>
{
    private readonly ICarService _carService;

    public CreateCarHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<CreateCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }

        var createdCar = await _carService.CreateCarAsync(request.CreateCarRequest);

        return createdCar;
    }
}
