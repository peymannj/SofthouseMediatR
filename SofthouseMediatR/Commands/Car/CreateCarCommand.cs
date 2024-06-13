using MediatR;
using SofthouseMediatR.Dto.Car;

namespace SofthouseMediatR.Commands.Car;

public class CreateCarCommand : IRequest<CreateCarResponse>
{
    public CreateCarRequest CreateCarRequest { get; }

    public CreateCarCommand(CreateCarRequest createCarRequest)
    {
        CreateCarRequest = createCarRequest;
    }
}
