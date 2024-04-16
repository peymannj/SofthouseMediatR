using MediatR;

namespace SofthouseMediatR.Commands;

public class DeleteCarCommand : IRequest<Guid>
{
    public Guid Id { get; }

    public DeleteCarCommand(Guid id)
    {
        Id = id;
    }
}
