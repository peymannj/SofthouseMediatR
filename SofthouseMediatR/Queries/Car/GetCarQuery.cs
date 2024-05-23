using MediatR;
using SofthouseMediatR.Dto.Car;

namespace SofthouseMediatR.Queries.Car;

public class GetCarQuery : IRequest<GetCarResponse>
{
    public Guid Id { get; }

    public GetCarQuery(Guid id) => Id = id;
}
