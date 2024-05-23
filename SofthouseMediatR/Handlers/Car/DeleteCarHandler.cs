using MediatR;
using SofthouseMediatR.Commands.Car;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers.Car;

public class DeleteCarHandler : IRequestHandler<DeleteCarCommand, Guid>
{
    private readonly ICarService _carService;

    public DeleteCarHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<Guid> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null");
        }
        
        if (request.Id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request), "Correct car Id not provided");
        }
        
        return await _carService.DeleteCarAsync(request.Id);
    }
}
