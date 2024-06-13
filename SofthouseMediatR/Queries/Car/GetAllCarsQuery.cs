using MediatR;
using SofthouseMediatR.Dto.Car;

namespace SofthouseMediatR.Queries.Car;

public class GetAllCarsQuery : IRequest<IEnumerable<GetCarResponse>>
{
}
