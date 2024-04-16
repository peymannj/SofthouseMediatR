using MediatR;
using SofthouseMediatR.Dto;

namespace SofthouseMediatR.Commands;

public class CreateCarCommand : IRequest<CreateCarResponse>
{
    public CreateCarRequest CreateCarRequest { get; }

    public CreateCarCommand(CreateCarRequest createCarRequest)
    {
        CreateCarRequest = createCarRequest;
    }
}
