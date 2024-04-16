using MediatR;
using SofthouseMediatR.Dto;
using SofthouseMediatR.Queries;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers;

public class GetAllCarsHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<GetCarResponse>>
{
    private readonly ICarService _carService;

    public GetAllCarsHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<IEnumerable<GetCarResponse>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken) =>
        await _carService.GetAllAsync();
}
