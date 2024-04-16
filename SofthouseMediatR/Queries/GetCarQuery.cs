using MediatR;
using SofthouseMediatR.Dto;

namespace SofthouseMediatR.Queries;

public class GetCarQuery : IRequest<GetCarResponse>
{
    public Guid Id { get; }

    public GetCarQuery(Guid id) => Id = id;
}
