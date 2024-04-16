using MediatR;
using SofthouseMediatR.Commands;
using SofthouseMediatR.Services.Interfaces;

namespace SofthouseMediatR.Handlers;

public class DeleteCarHandler : IRequestHandler<DeleteCarCommand, Guid>
{
    private readonly ICarService _carService;

    public DeleteCarHandler(ICarService carService)
    {
        _carService = carService;
    }

    public async Task<Guid> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        if (request is null || request.Id == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(request), "Request cannot be null or invalid");
        }
        
        return await _carService.DeleteCarAsync(request.Id);
    }
}
