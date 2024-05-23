using MediatR;
using SofthouseMediatR.Dto.Car;

namespace SofthouseMediatR.Commands.Car;

public class UpdateCarCommand : IRequest<UpdateCarResponse>
{
    public Guid Id { get; }

    public UpdateCarRequest UpdateCarRequest { get; }

    public UpdateCarCommand(Guid id, UpdateCarRequest updateCarRequest)
    {
        Id = id;
        UpdateCarRequest = updateCarRequest;
    }
}
