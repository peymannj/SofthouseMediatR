using MediatR;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Queries.Car;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Car;

public class GetCarByIdHandler : IRequestHandler<GetCarQuery, GetCarResponse>
{
    private readonly ICarService _carService;

    public GetCarByIdHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<GetCarResponse> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }

        if (request.Id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request), "Car Id not provided");
        }

        return await _carService.GetByIdAsync(request.Id);
    }
}
