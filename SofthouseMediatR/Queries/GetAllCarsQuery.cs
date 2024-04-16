using MediatR;
using SofthouseMediatR.Dto;

namespace SofthouseMediatR.Queries;

public class GetAllCarsQuery : IRequest<IEnumerable<GetCarResponse>>
{
}
