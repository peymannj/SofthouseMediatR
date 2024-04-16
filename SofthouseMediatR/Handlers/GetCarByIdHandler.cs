using MediatR;
using SofthouseMediatR.Dto;
using SofthouseMediatR.Queries;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers;

public class GetCarByIdHandler : IRequestHandler<GetCarQuery, GetCarResponse>
{
    private readonly ICarService _carService;

    public GetCarByIdHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<GetCarResponse> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        if (request is null || request.Id == Guid.Empty)
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
