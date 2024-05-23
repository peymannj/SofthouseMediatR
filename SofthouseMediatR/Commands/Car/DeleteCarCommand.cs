using MediatR;

namespace SofthouseMediatR.Commands.Car;

public class DeleteCarCommand : IRequest<Guid>
{
    public Guid Id { get; }

    public DeleteCarCommand(Guid id)
    {
        Id = id;
    }
}
