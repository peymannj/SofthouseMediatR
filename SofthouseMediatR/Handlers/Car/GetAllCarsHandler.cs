using MediatR;
using SofthouseMediatR.Dto.Car;
using SofthouseMediatR.Queries.Car;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Car;

public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<GetCarResponse>>
{
    private readonly ICarService _carService;

    public GetAllCarsHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IEnumerable<GetCarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }
 
        return await _carService.GetAllAsync();
    }
}
